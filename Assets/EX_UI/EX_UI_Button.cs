using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EX_UI_Button : MonoBehaviour
{
    public void OnClick_ButtonFunction()
    {
        print("button clicked");
    }

    public void OnClick_ButtonFunction(int value)
    {
        print($"int {value} is passed to button function");
    }

    public void OnClick_ButtonFunction(string value)
    {
        print($"string {value} is passed to button function");
    }
}
