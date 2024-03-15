using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CharacterController_SimpleMove : MonoBehaviour
{
    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    //https://docs.unity3d.com/kr/2022.3/ScriptReference/CharacterController.SimpleMove.html
    [SerializeField]
    float speed = 3.0F;
    [SerializeField]
    float rotateSpeed = 1.0F;

    void Update()
    {
        // Rotate around y - axis
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

        // Move forward & backward
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * curSpeed);
    }
}
