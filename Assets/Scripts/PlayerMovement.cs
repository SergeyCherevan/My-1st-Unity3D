using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public Transform groundCheck;
    public LayerMask groundMask;
    public Animator animator;

    public float speed = 10f;
    public float gravity = 9.8f;
    public float jumpHeight = 3f;
    public float groundDistanse = 0.5f;

    Vector3 velocity = new Vector3();
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistanse, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * gravity);
        }

        velocity.y -= gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        float x = Input.GetAxis("Horizontal"),
              z = Input.GetAxis("Vertical");

        Vector3 displacement = transform.right * x + transform.forward * z;
        characterController.Move(displacement * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.C))
        {
            characterController.height = 1.5f;
        }
        else
        {
            characterController.height = 2.5f;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 20f;
        }
        else
        {
            speed = 10f;
        }
    }
}
