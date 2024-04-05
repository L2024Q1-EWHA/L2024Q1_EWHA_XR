using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class W05_1_ChattingSystem_Sample_Step2_Room : MonoBehaviourPunCallbacks
{
    List<string> ChatLogs = new List<string>();
    public TMP_Text ChatLog;
    public TMP_InputField UserInput;
    public TMP_Text Users;

    void Start()
    {
        if (string.IsNullOrEmpty(PhotonNetwork.NickName)) PhotonNetwork.NickName = "Player " + Random.Range(0, 1000);
        print("Player Name: " + PhotonNetwork.NickName);

        print("PlayerList");
        foreach (var Player in PhotonNetwork.PlayerList)
        {
            print("Player:" + Player.NickName);
        }
        UpdateUsers();
        UserInput.ActivateInputField();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        print(newPlayer.NickName + " has entered the room");
        UpdateUsers();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        print(otherPlayer.NickName + " has left the room");
        UpdateUsers();
    }

    void UpdateUsers()
    {
        string users = "Users\n";
        foreach (var Player in PhotonNetwork.PlayerList)
        {
            if (Player.NickName == PhotonNetwork.LocalPlayer.NickName)
            {
                users += Player.NickName + "(Me)\n";
            }
            else
            {
                users += Player.NickName + "\n";
            }
        }
        Users.text = users;
    }

    public void OnClick_SendMessage()
    {
        string Sender = PhotonNetwork.LocalPlayer.NickName;
        string Input = UserInput.text;
        string Message = Sender + ":" + Input;
        print("new message:" + Message);
        photonView.RPC("UpdateMessage", RpcTarget.AllBuffered, Message);
        UserInput.text = "";
        UserInput.ActivateInputField();
    }

    [PunRPC]
    void UpdateMessage(string _Message)
    {
        ChatLogs.Add(_Message);
        ChatLog.text = "";
        for (int i = 0; i < ChatLogs.Count; i++)
        {
            ChatLog.text += ChatLogs[i] + "\n";
        }
    }
}
