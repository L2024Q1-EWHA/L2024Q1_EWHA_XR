using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_MouseLock : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if(Input.GetMouseButtonDown(0))
        {
            if (Cursor.lockState == CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
