using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed;
    public float horizontalSpeed;
    public float leftPosition;
    public float centralPosition;
    public float rightPosition;
    private Vector3 pos;
    private float posxTarget;
    int carril = 1;
    public Animator anim;
    public Rigidbody rb;
    public float jumpForce;
    public float gravityForce;
    private bool isGrounded;
    public float speedMultiplier = 2;
    public float maxSpeed = 70;


    void Start()
    {
        pos = transform.position;
        posxTarget = centralPosition;
    }

    void Update()
    {
        if (GameManager.instance.isPlaying)
        {
            Vector3 velocity = rb.velocity;
            velocity.z = Mathf.Lerp(velocity.z, forwardSpeed, forwardSpeed * Time.deltaTime);
            
            velocity.y -=Time.deltaTime * gravityForce;
            velocity.y = Mathf.Clamp(velocity.y, -20, 15);
            //velocity.z = forwardSpeed;
            rb.velocity = velocity;

            pos.z = transform.position.z;
            pos.y = transform.position.y;
            pos.x = Mathf.Lerp(pos.x, posxTarget, horizontalSpeed * Time.deltaTime);

            transform.position = pos;
            
        }
            anim.SetFloat("moveSpeed",Vector3.Magnitude(rb.velocity) /50);

    }

    public void MoveLeft()
    {
        if (carril > 0)
        {
            carril--;

            ChangeDirection();
        }
    }
    public void MoveRight()
    {
        if (carril < 2)
        {
            carril++;

            ChangeDirection();
        }
    }
    void ChangeDirection() 
    {

        switch (carril)
        {
            case 0:
                posxTarget = leftPosition;
                break;
            case 1:
                posxTarget = centralPosition;
                break;
            default:
                posxTarget = rightPosition;
                break;
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            isGrounded = false;
            anim.SetBool("isJumping",true);
            //Invoke("JumpDown", .5f);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            isGrounded = true;
            anim.SetBool("isJumping", false);
        }
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Floor"))
    //    {
    //        isGrounded = false;
    //    }
    //}
    public void SpeedUp() 
    {
        if (forwardSpeed < maxSpeed) forwardSpeed += speedMultiplier;
    }

    private void JumpDown()
    {
        rb.AddForce(Vector3.up * -jumpForce, ForceMode.VelocityChange);
    }
}
