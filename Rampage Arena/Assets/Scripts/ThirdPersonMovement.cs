using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;

public class ThirdPersonMovement : AttributesSync
{
    public CharacterController controller;
    public float speed;
    public float verticalVelocity;
    public float grav = 0.5f;
    public float jumpForce;
    public float airSpeed;
    public float jumps;
    public Animator ani;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public bool locked = false;
    public bool jlock = false;
    public bool gravAffect = true;
    private Alteruna.Avatar ava;
    [SynchronizableField] public int playNum;
    [SynchronizableField] bool walk;
    [SynchronizableField] bool crouch;
    [SynchronizableField] bool jump;
    [SynchronizableField] public bool ground;

    void Awake()
    {
        ava = GetComponent<Alteruna.Avatar>();
        if (!ava.IsMe) return;
    }
    private void Start()
    {
        ava = GetComponent<Alteruna.Avatar>();
        if (!ava.IsMe) return;
        playNum = GameObject.Find("PLAYERMANAGER").GetComponent<PlayerManager>().playerNumber;
    }
    void Update()
    {
        if (walk) ani.SetBool("Walk", true);
        else ani.SetBool("Walk", false);
        if (crouch) ani.SetBool("Crouch", true);
        else ani.SetBool("Crouch", false);
        if (jump) ani.SetBool("Jump", true);
        else ani.SetBool("Jump", false);
        if (ground) ani.SetBool("Ground", true);
        else ani.SetBool("Ground", false);
        if (!ava.IsMe) return;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;


        if (direction.magnitude >= 0.1f && locked == false)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            if (controller.isGrounded)
            {
                controller.Move(moveDir.normalized * speed * Time.deltaTime);
                walk = true;
            }
            else
            {
                controller.Move(moveDir.normalized * airSpeed * Time.deltaTime);
            }
            
        }
        else
        {
            walk = false;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, Camera.main.transform.eulerAngles.y, transform.rotation.eulerAngles.z);
        }
        
        Vector3 moveHigh = new Vector3(0, verticalVelocity, 0);
        controller.Move(moveHigh * Time.deltaTime);
        
        if (Input.GetKeyDown(KeyCode.Space) && jumps > 0 && jlock == false)
            {
            
            verticalVelocity = jumpForce;
            jumps--;
            jump = true;
        }
        else
        {
            jump = false;
        }


        if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space) == false)
        {
            jumps = 2;
            verticalVelocity = 0;
            ground = true;

        }
        else if (-2 < verticalVelocity && verticalVelocity < 3 && gravAffect)
        {
            verticalVelocity += grav / 1.4f;

        }
        else if (gravAffect)
        {
            verticalVelocity += grav;
            ground = false;
        }
        else
        {
            verticalVelocity = 0;
        }

        if (verticalVelocity <= -10) verticalVelocity = -10;

        
    }
}
