using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W03_MouseEvent : MonoBehaviour
{
    private void OnMouseDown()
    {
        print(gameObject.name);
    }

    private void OnMouseUp()
    {
        print(transform.position);
    }
}
