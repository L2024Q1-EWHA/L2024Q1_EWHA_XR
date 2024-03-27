using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W04_DontDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        var GO = FindObjectsOfType<W04_DontDestroyOnLoad>();
        if (GO.Length == 1)
        {
            print("Dont Destroy");
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            print("Destroy");
            Destroy(gameObject);
        }
    }
}
