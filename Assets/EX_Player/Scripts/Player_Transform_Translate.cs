using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Transform_Translate : MonoBehaviour
{

    public Transform ObjectToTranslate;

    float translateSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        Translate();
    }


    void Translate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            ObjectToTranslate.Translate(Vector3.forward * translateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            ObjectToTranslate.Translate(-Vector3.forward * translateSpeed * Time.deltaTime);
        }
    }
}
