using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class characterController : MonoBehaviour
{
    CharacterController cc;
    Animator animator;
    public Vector3 inputVec;
    private Vector3 moveDirection = Vector3.zero;
    public bool jump;
    //Player stats
    [SerializeField] float moveSpeed = 7.0f;
    [SerializeField] float jumpSpeed = 5.0f;
    [SerializeField] float gravity = 9.81f;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    //Character movement
    public void OnMove(InputValue input)
    {
        //Access the inputs to determine movement
        inputVec = input.Get<Vector2>();
    }

    //Character jump
    public void OnJump()
    {
        jump = true;
    }

    private void FixedUpdate()
    {
        //Set animator bool as the situation of isGrounded
        animator.SetBool("Grounded", cc.isGrounded);

        //When player is on the ground
        if (cc.isGrounded)
        {
            //Plays the run animation when moveSpeed is larger than idle value
            animator.SetFloat("MoveSpeed", moveDirection.magnitude);
            //Move according to the inputs
            moveDirection = new Vector3(inputVec.x, 0.0f, inputVec.y);
            moveDirection *= moveSpeed;
            //When player jumps
            if (jump)
            {
                //Apply force in the y axis
                moveDirection.y += Mathf.Sqrt(jumpSpeed * gravity);
                //Make sure player doesn't jump in the air
                jump = false;
            }
        }
        // Face in dir of move
        if (moveDirection.magnitude > float.Epsilon)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }

        //Apply gravity
        moveDirection.y -= gravity * Time.fixedDeltaTime;
        //Move using character controller
        cc.Move(moveDirection * Time.fixedDeltaTime);
    }


    // Update is called once per frame
    void Update()
    {
    
    }
}
