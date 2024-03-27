using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class W04_LoadScene2 : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Robot_Transform")
        {
            SceneManager.LoadScene("W04_Scene2");
        }
    }
}
