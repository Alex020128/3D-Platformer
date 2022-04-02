using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class simpleControls : MonoBehaviour
{
    Rigidbody rb;

    public Vector3 inputVec;
    public float moveSpeed;
    public float turnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveSpeed = 3.0f;
        turnSpeed = 2.0f;
    }

    public void OnMove(InputValue input)
    {
        inputVec = input.Get<Vector2>();
        
        //rb.transform.position += Vector3.right * Time.deltaTime * moveVec.x * moveSpeed;
        //rb.transform.position += Vector3.forward * Time.deltaTime * moveVec.y * moveSpeed;
    }
    void FixedUpdate()
    { 
        //rb.AddTorque(Vector3.up * turnSpeed * moveVec.x); // Add rotation.
        rb.AddRelativeForce(new Vector3(moveSpeed * inputVec.x, 0.0f, moveSpeed * inputVec.y)); // Add force in direction of movement.
    }
    // Update is called once per frame
    void Update()
    {
        //float x = Input.GetAxis("Horizontal"); //Axis from 0..1
        //bool fired = Input.GetButton("Fire1"); // Fire  on/ of

        //float y = Input.GetAxis("Vertical"); //Axis from 0..1

        //rb.transform.position += Vector3.right * Time.deltaTime * x;
        //rb.transform.position += Vector3.forward * Time.deltaTime * y;

        //if (fired)
        //{
        //Debug.Log("!");
        //}
    }
}
