using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
        // create variables
        private float speed = 15.0f;
        private float turnSpeed = 25.0f;
        private float horizontalInput;
        private float verticalInput;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this is where we get player input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        //make the car move forward
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
        //rotate the car
        transform.Rotate(Vector3.up, Time.deltaTime * horizontalInput * turnSpeed);

    }
}
