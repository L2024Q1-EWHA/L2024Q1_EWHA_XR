using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class EX_MultiPlayer_NetworkManager : MonoBehaviourPunCallbacks
{
    string PlayerPrefabName = "MultiPlayerPrefab";
    public string PlayerNickName = "";
    public string RoomName = "My Room";
    public int MaximumPlayers = 8;

    private void Start()
    {
        Screen.SetResolution(800, 600, false);  // fullscreen = false

        // AppId와 GameVersion의 버전은 앱 사이에 동일해야 함
        PhotonNetwork.GameVersion = "0.1";

        // 게임에서 사용할 사용자의 이름을 랜덤으로 생성함
        if (string.IsNullOrEmpty(PlayerNickName))
        {
            int num = Random.Range(0, 1000);
            PlayerNickName = "Player " + num;
        }
        PhotonNetwork.NickName = PlayerNickName;

        // 서버 접속 절차: 네임 서버 --> 마스터 서버 --> 게임 서버 (Room)
        // 게임에 참여하면 마스터 클라이언트가 구성한 씬에 자동으로 동기화하도록 함
        PhotonNetwork.AutomaticallySyncScene = true;

        print("Starting Connect Process...");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        print("Connected To Master");
        // 로비에 접속함. 이후 OnJoinedLobby()가 자동 호출됨
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    public override void OnJoinedLobby()
    {
        print("Joined Lobby");
        RoomOptions ro = new RoomOptions()
        {
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = MaximumPlayers
        };
        // 게임 서버에 접속함. 성공하면 OnJoinedRoom()가 자동 호출됨
        PhotonNetwork.JoinOrCreateRoom(RoomName, ro, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        print("Joined Room");

        Vector2 originPos = Random.insideUnitCircle * 2.0f;
        PhotonNetwork.Instantiate(PlayerPrefabName, new Vector3(originPos.x, 0, originPos.y), Quaternion.identity);
    }
}
