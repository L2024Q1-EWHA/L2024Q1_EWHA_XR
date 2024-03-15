using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_ConstrainHeadRotation : MonoBehaviour
{
    public Transform ObjectToConstrainRotation;

    float rotationSpeed = 5f, XRotation, YRotation;

    [SerializeField]
    float YRotationLimit = 60f;

    void Update()
    {
        ConstrainRotation();
    }

    void ConstrainRotation()
    {
        float XaxisRotation = Input.GetAxis("Mouse X") * rotationSpeed;
        float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSpeed;
        // XRotation --> up~down
        XRotation -= YaxisRotation;
        XRotation = Mathf.Clamp(XRotation, -40f, 20f);
        // YRotation --> left~right
        YRotation += XaxisRotation;
        YRotation = Mathf.Clamp(YRotation, -YRotationLimit, YRotationLimit);
        //print($"XRot: {XRotation}, YRot: {YRotation}");
        ObjectToConstrainRotation.transform.localRotation = Quaternion.Euler(XRotation, YRotation, 0f);
    }
}
