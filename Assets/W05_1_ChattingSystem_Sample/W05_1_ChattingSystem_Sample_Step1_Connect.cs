using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;


public class W05_1_ChattingSystem_Sample_Step1_Connect : MonoBehaviourPunCallbacks
{
    // 연결상태를 표시하는 Panel
    public GameObject Panel_ConnectionStatus;
    public TMP_Text ConnectionStatus;

    // 사용자의 이름(NickName)을 입력하는 Panel
    public GameObject Panel_SetUserName;
    public TMP_InputField UserNameInput;
    public GameObject UserConnectButton;

    // Chatting Interface가 있는 Scene 설정
    public Object ChattingScene;

    void Start()
    {
        // Panel 활성화 설정
        Panel_ConnectionStatus.SetActive(true);
        Panel_SetUserName.SetActive(false);

        // 화면의 크기 설정
        Screen.SetResolution(800, 600, false); // fullscreen = false

        // GameVersio 설정
        PhotonNetwork.GameVersion = "0.1";

        // 서버 접속 절차: 네임 서버 --> 마스터 서버 --> 게임 서버 (Room)
        // 게임에 참여하면 마스터 클라이언트가 구성한 씬에 자동으로 동기화하도록 함
        // 씬이 바뀔 경우에도 동기화됨
        PhotonNetwork.AutomaticallySyncScene = true;

        // 접속 시작
        print("Starting Connect Process...");
        ConnectionStatus.text = "접속을 시작합니다...";
        PhotonNetwork.ConnectUsingSettings();
    }


    public override void OnConnectedToMaster()
    {
        print("Connected To Master");
        ConnectionStatus.text = "Master에 접속했습니다.";

        // 로비에 접속함. 이후 OnJoinedLobby()가 자동 호출됨
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }


    public override void OnJoinedLobby()
    {
        print("Joined Lobby");
        ConnectionStatus.text = "이름을 입력하세요.";
        Panel_SetUserName.SetActive(true);
    }

    public void OnClick_JoinOrCreateRoom()
    {
        if (string.IsNullOrEmpty(UserNameInput.text) || UserNameInput.text == "이름을 입력하세요.")
        {
            UserNameInput.text = "이름을 입력하세요.";
        }
        else
        {
            print("User Name:" + UserNameInput.text);
            RoomOptions ro = new RoomOptions()
            {
                IsVisible = true,
                IsOpen = true,
                MaxPlayers = 8
            };

            PhotonNetwork.NickName = UserNameInput.text;
            print("사용자의 이름은 " + PhotonNetwork.NickName + "입니다.");
            // 게임 서버에 접속함. 성공하면 OnJoinedRoom()가 자동 호출됨
            PhotonNetwork.JoinOrCreateRoom("Room", ro, TypedLobby.Default);
        }
    }

    public override void OnJoinedRoom()
    {
        print(PhotonNetwork.NickName + " has joined Room");
        string ChattingSceneName = ChattingScene.name;
        PhotonNetwork.LoadLevel(ChattingSceneName); 
    }
    
}
