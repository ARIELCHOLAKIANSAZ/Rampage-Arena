﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
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

    void Awake()
    {
        ava = GetComponent<Alteruna.Avatar>();
        if (!ava.IsMe) return;
    }
    void Update()
    {
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
                ani.SetBool("Walk", true);
            }
            else
            {
                controller.Move(moveDir.normalized * airSpeed * Time.deltaTime);
            }
            
        }
        else
        { 
            ani.SetBool("Walk", false);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, Camera.main.transform.eulerAngles.y, transform.rotation.eulerAngles.z);
        }
        
        Vector3 moveHigh = new Vector3(0, verticalVelocity, 0);
        controller.Move(moveHigh * Time.deltaTime);
        
        if (Input.GetKeyDown(KeyCode.Space) && jumps > 0 && jlock == false)
            {
            
            verticalVelocity = jumpForce;
            jumps--;
            ani.SetBool("Jump", true);
        }
        else
        {
            ani.SetBool("Jump", false);
        }


        if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space) == false)
        {
            jumps = 2;
            verticalVelocity = 0;
            ani.SetBool("Ground", true);

        }
        else if (-2 < verticalVelocity && verticalVelocity < 3 && gravAffect)
        {
            verticalVelocity -= grav / 1.3f;

        }
        else if (gravAffect)
        {
            verticalVelocity -= grav;
            ani.SetBool("Ground", false);
        }
        else
        {
            verticalVelocity = 0;
        }


        
    }
}