using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EX_Mouse_Event : MonoBehaviour
{
    private void OnMouseEnter()
    {
        print("MouseEnter");
    }

    private void OnMouseExit()
    {
        print("MouseExit");
    }

    private void OnMouseOver()
    {
        print("MouseOver");
    }

    private void OnMouseDown()
    {
        print("MouseDown");
    }

    private void OnMouseUp()
    {
        print("MouseUp");
    }

    private void OnMouseDrag()
    {
        print("MouseDrag");
    }

    private void OnMouseUpAsButton()
    {
        print("MouseUpAsButton");
    }
}
