using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{

    public CharacterController controller;
    public Transform cam;
    public Transform groundCheck;
    public LayerMask groundMask;
    
    public float groundDistance = 0.4f;
    public float speed = 3f;

    Vector3 velocity;
    public float gravity = -9.81f;
    public float jumpHeight = 1f;

    public float turningTimeSmoothly = 0.1f;
    private float turningVelocitySmoothly;
    
    private float kx;
    private float kz;

    private bool isGrounded;
    void Start()
    {
        
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        kx = Input.GetAxisRaw("Horizontal");
        kz = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(kx, 0f, kz).normalized;
        
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime * 2);

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turningVelocitySmoothly,
                turningTimeSmoothly);
            
            transform.rotation = Quaternion.Euler(0f, angle, 0);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection * speed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
