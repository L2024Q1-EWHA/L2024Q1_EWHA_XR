using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W04_Door_AnimationControl : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Robot_Transform")
        {
            print("trigger enter");
            animator.SetInteger("Control", 1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Robot_Transform")
        {
            print("trigger exit");
            animator.SetInteger("Control", 2);
        }
    }
}
