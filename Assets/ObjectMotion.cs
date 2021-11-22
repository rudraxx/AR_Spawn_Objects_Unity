using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectMotion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Set rotation of the object based on the current second

        int _rotationSpeed = 15;
        //// Rotate the object around its local X axis at 1 degree per second
        //transform.Rotate(Vector3.right * Time.deltaTime);
        transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);

        //// ...also rotate around the World's Y axis
        //transform.Rotate(Vector3.up * Time.deltaTime, Space.World);


    }
}
