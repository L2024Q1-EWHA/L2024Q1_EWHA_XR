using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EX_UI_Dropdown : MonoBehaviour
{
    public void Dropdown_SelectFunction()
    {
        print("Select Done");        
    }

    public void Dropdown_SelectFunction_DynamicInt(int i)
    {
        string s = $"Select {i} Done.";
        print(s);        
    }
}
