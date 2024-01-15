using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class ThirdPersonMovement : MonoBehaviour
{
    public GameObject me;
    
    public CharacterController controller;
    public Transform cam;
    public Transform groundCheck;
    public LayerMask groundMask;
    
    public Animator animator;
    
    public float groundDistance = 0.4f;
    public float speed = 3f;
    public float knokbackForce = 3f;

    Vector3 velocity;
    Vector3 moveDirection;
    public float gravity = -9.81f;
    public float jumpHeight = 1f;

    public float turningTimeSmoothly = 0.1f;
    private float turningVelocitySmoothly;
    
    private float kx;
    private float kz;

    private bool isGrounded;
    
    private MeshRenderer meRender;
    public bool alive = true;
    public bool won = true;
    
    private float targetAngle;
    private float angle;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        alive = true;
        won = false;
    }

    void Update()
    {
        //Camera and Player Movement
        
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
            targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turningVelocitySmoothly,
                turningTimeSmoothly);
            
            transform.rotation = Quaternion.Euler(0f, angle, 0);

            moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection * speed * Time.deltaTime);
        }
      

        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
        //Animations 

        //RunForward
        if (direction.magnitude >= 0.1f)
        {
            animator.SetBool("isWalking", true);
        }
        else 
        {
            animator.SetBool("isWalking", false);
        }
        
        //JumpWhileRunning
        if (animator.GetBool("isWalking") == false && Input.GetButtonDown("Jump"))
        {
            Debug.Log("salto");
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name.Contains("FinalLayer"))
        {
            Invoke("PlayerDeath", 0.2f);
        }
        if (collision.gameObject.name.Contains("Bomb"))
        {
            Invoke("PlayerDeath", 0.2f);
        }
        if (collision.gameObject.name.Contains("FinishLine"))
        {
            won = true;
            me.SetActive(true);
            Destroy(gameObject, 2f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Enemy"))
        {
            Invoke("PlayerDeath", 0f);
            //GameObject.SetGameObjectsActive(false);
        }
        if (collision.gameObject.name.Contains("Cylinder"))
        {
            alive = true;
            me.SetActive(true);
            Destroy(collision.gameObject, 0.5f);
        }
        
        
    }
    private void PlayerDeath()
    {
        if (me != null)
        {
            alive = false;
            me.SetActive(false);
        }
    }
}
