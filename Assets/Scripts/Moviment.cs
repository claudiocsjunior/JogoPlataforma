using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moviment : MonoBehaviour
{
    public CharacterController controller;

    private Animator animator;
    public float speed = 6f;

    public float turnSmoothTime = 0.1f;

    public float jumpHeight = 1f;

    public GameObject person;

    

    public Transform cam;

    public float gravity = -15f;

    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public Transform groundCheck;

    float turnSmoothVelocity;
    Vector3 velocity;
    bool isGrounded;
    void Start(){
        animator = person.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!EstadoPersonagem.Instance.pausado){
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if(isGrounded && velocity.y < 0){
                
                velocity.y = -2f;
            }

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if(isGrounded){
                if(direction.magnitude >= 0.1f){
                    animator.SetInteger("transition", 1);
                }else{
                    animator.SetInteger("transition", 0);
                }
            }else{
                animator.SetInteger("transition", 2);
            }

            if(direction.magnitude >= 0.1f)
            {   
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * speed * Time.deltaTime);
            }

            if(Input.GetButtonDown("Jump") && isGrounded){
                animator.SetInteger("transition", 2);
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }
}
