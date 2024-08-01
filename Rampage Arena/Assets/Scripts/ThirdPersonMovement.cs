using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    public float turnSmoothTime;
    float turnSmoothVelocity;
    private float verticalVelocity;
    public float grav;
    public float jumpForce;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, Camera.main.transform.eulerAngles.y, transform.rotation.eulerAngles.z);

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            moveDir.y = verticalVelocity;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        if (controller.isGrounded)
        {
            verticalVelocity = -grav * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
            }
            
        }
        else
        {
            verticalVelocity -= grav;
        }

        Vector3 moveHigh = new Vector3(0, verticalVelocity, 0);
        controller.Move(moveHigh * Time.deltaTime);
    }
}
