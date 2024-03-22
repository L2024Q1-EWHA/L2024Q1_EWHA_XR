using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W03_AnimationController : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        print("M for MENU");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)) {
            if(animator.GetInteger("Control") == 0 || animator.GetInteger("Control") == 2)
            {
                print("Panel Moving Up");
                animator.SetInteger("Control", 1);
            }else if(animator.GetInteger("Control") == 1)
            {
                print("Panel Moving Down");
                animator.SetInteger("Control", 2);
            }
            
        }
    }
}
