using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camControlnShoot : MonoBehaviour
{

    float xRot, yRot = 0f;
    public Rigidbody ball;
    public float rotationSpeed = 5f;
    public float shootingPower = 30f;

    void Update()
    {
        transform.position = ball.position;
     

        if (Input.GetMouseButton(1))
        {
            xRot += Input.GetAxis("Mouse X") * rotationSpeed;
            yRot += Input.GetAxis("Mouse Y") * rotationSpeed ;
                if(yRot < -40f)
                 {
                    yRot = -40f;
                 }
        transform.rotation = Quaternion.Euler(yRot, xRot, 0f);  //Quaternion rot is how unity handles rotation
        
     }

        if(Input.GetMouseButton(0))
        {
            ball.velocity = transform.forward * shootingPower;
        }
    }
}
