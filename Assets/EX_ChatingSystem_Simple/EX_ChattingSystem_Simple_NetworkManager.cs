using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

public class EX_ChattingSystem_Simple_NetworkManager : MonoBehaviourPunCallbacks
{
    public TMP_Text ConnectionStatus;
    public TMP_InputField UserNameInput;
    public GameObject UserConnectButton;

    void Start()
    {
        UserNameInput.gameObject.SetActive(false);
        UserConnectButton.SetActive(false);

        Screen.SetResolution(800, 600, false); // fullscreen = false

        // AppId와 GameVersion의 버전은 앱 사이에 동일해야 함
        PhotonNetwork.GameVersion = "0.1";

        // 서버 접속 절차: 네임 서버 --> 마스터 서버 --> 게임 서버 (Room)
        // 게임에 참여하면 마스터 클라이언트가 구성한 씬에 자동으로 동기화하도록 함
        // 씬이 바뀔 경우에도 동기화됨
        PhotonNetwork.AutomaticallySyncScene = true;

        // 접속 시작
        print("Starting Connect Process...");
        ConnectionStatus.text = "Starting Connect Process...";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        print("Connected To Master");
        ConnectionStatus.text = "Connected To Master";

        // 로비에 접속함. 이후 OnJoinedLobby()가 자동 호출됨
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    public override void OnJoinedLobby()
    {
        print("Joined Lobby");
        ConnectionStatus.text = "Input User Name";

        UserNameInput.gameObject.SetActive(true);
        UserConnectButton.SetActive(true);
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

        string chattingSceneName = "EX_ChattingSystem_Simple_Step2_Chat";
        PhotonNetwork.LoadLevel(chattingSceneName); // string or int. not object.name.ToString
    }
}
