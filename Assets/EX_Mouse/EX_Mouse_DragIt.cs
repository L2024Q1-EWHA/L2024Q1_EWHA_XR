using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EX_Mouse_DragIt : MonoBehaviour
{
    public GameObject DragableObject;
    Vector3 CurrentPos;
    Vector3 DiffPos;

    void Start()
    {
        CurrentPos = DragableObject.transform.position;
    }

    void Update()
    {
        //FollowMouse();
        Drag();
    }

    private void Drag()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            DiffPos = Camera.main.ScreenToWorldPoint(mousePos) - CurrentPos;
        }
        if(Input.GetMouseButton(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log(hit.transform.name);
                Debug.Log("hit");
                print(hit.collider.name);
                if(hit.collider.name == DragableObject.name)
                {
                    Vector3 mousePos = Input.mousePosition + DiffPos;
                    mousePos.z = CurrentPos.z - Camera.main.transform.position.z;
                    Vector3 Pos = Camera.main.ScreenToWorldPoint(mousePos);

                    print($"Pos: {Pos}");
                    DragableObject.transform.position = Pos;
                }
            }
        }
    }

    void FollowMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = DragableObject.transform.position.z - Camera.main.transform.position.z;
        Vector3 Pos = Camera.main.ScreenToWorldPoint(mousePos);

        print($"Pos: {Pos}");
        DragableObject.transform.position = Pos;
    }
}
