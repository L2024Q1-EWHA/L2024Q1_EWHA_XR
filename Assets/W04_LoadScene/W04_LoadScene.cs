using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class W04_LoadScene : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Robot_Transform")
        {
            if (gameObject.name == "Scene1")
            {
                SceneManager.LoadScene("W04_Scene1");
            }
            else if (gameObject.name == "Scene2")
            {
                SceneManager.LoadScene("W04_Scene2");
            }
        }
    }
}
