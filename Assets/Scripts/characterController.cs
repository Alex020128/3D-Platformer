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
    [SerializeField] float jumpSpeed = 5.0f;
    [SerializeField] float gravity = 9.81f;

    public float maxTime = 0.5f;
    private float curTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    public void OnMove(InputValue input)
    {
        inputVec = input.Get<Vector2>();
    }

    public void OnJump()
    {
        jump = true;
    }

    private void FixedUpdate()
    {
        animator.SetBool("Grounded", cc.isGrounded);

        if (cc.isGrounded)
        {
            animator.SetFloat("MoveSpeed", moveDirection.magnitude);

            moveDirection = new Vector3(inputVec.x, 0.0f, inputVec.y);
            moveDirection *= 10.0f;

            if (jump)
            {
                moveDirection.y += Mathf.Sqrt(jumpSpeed * gravity);
                jump = false;
            }
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
        curTime = Mathf.Clamp(curTime + Time.deltaTime, 0.0f, maxTime);
    }
}
