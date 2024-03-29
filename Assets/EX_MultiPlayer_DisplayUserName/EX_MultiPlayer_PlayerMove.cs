using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class EX_MultiPlayer_PlayerMove : MonoBehaviourPunCallbacks
{
    public TMP_Text PlayerName;
    public Transform Canvas;

    private void Start()
    {
        print("NickName:" + PhotonNetwork.NickName);
        PlayerName.text = photonView.Owner.NickName;
        if (photonView.IsMine)
        {
            PlayerName.color = Color.green;
        }
        else
        {
            PlayerName.color = Color.red;
        }
    }
    void Update()
    {
        if (photonView.IsMine)
        {
            float h = Input.GetAxisRaw("Horizontal") * Time.deltaTime * 500f;
            float v = Input.GetAxisRaw("Vertical") * Time.deltaTime * 3f;
            transform.Rotate(0, h, 0);
            transform.Translate(0, 0, v);
        }
        Canvas.forward = Camera.main.transform.forward;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "FallDetector")
        {
            print("collision:falling");
            transform.position = Random.insideUnitCircle * 2.0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FallDetector")
        {
            print("trigger:falling");
            transform.position = Random.insideUnitCircle * 2.0f;
        }
    }
}
