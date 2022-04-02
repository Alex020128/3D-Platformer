using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class characterController : MonoBehaviour
{
    CharacterController cc;

    public Vector3 inputVec;

    private Vector3 moveDirection = Vector3.zero;
    [SerializeField] float jumpSpeed = 8.0f;
    [SerializeField] float gravity = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    public void OnMove(InputValue input)
    {
        inputVec = input.Get<Vector2>();
    }

    public void OnJump(InputValue input)
    {
        //moveDirection.y = jumpSpeed;
    }

    private void FixedUpdate()
    {
        if (cc.isGrounded)
        {
            moveDirection = new Vector3(inputVec.x, 0.0f, inputVec.y);
            moveDirection *= 10.0f;
        }
        // Face in dir of move
        if (moveDirection.magnitude > float.Epsilon)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }

        moveDirection.y -= gravity * Time.fixedDeltaTime;

        cc.Move(moveDirection * Time.fixedDeltaTime);
    }


        // Update is called once per frame
        void Update()
    {
        
    }
}
