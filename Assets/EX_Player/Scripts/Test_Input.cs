using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Input : MonoBehaviour
{
    float translateSpeed = 3f;
    public GameObject Arrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //print(Input.GetAxis("Horizontal"));
        if (Input.GetKey(KeyCode.UpArrow)) 
        {
            //transform.position += transform.TransformDirection(transform.forward * translateSpeed * Time.deltaTime);
            transform.Translate(transform.forward * translateSpeed * Time.deltaTime);
            //transform.Translate(Vector3.forward * translateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-transform.forward * translateSpeed * Time.deltaTime);
            //transform.Translate(-Vector3.forward * translateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, -3 * 10 * Time.deltaTime);
            print($"transform.forward: {transform.forward}, Vector3.forward{Vector3.forward}, transform.rotation{transform.rotation}");
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            
            transform.Rotate(Vector3.up, 3 * 10 * Time.deltaTime);
            print($"transform.forward: {transform.forward}, Vector3.forward{Vector3.forward}, transform.rotation{transform.rotation}");
        }

        if(Input.GetKey(KeyCode.Space)) {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
        }
        //transform.rotation = Quaternion.identity;
        //Arrow.transform.rotation = Quaternion.LookRotation(transform.forward, Vector3.up);
        Arrow.transform.rotation = transform.rotation;
    }

}
