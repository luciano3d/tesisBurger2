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
            //velocity.z = forwardSpeed;
            rb.velocity = velocity;
            pos.z = transform.position.z;
            pos.y = transform.position.y;
            pos.x = Mathf.Lerp(pos.x, posxTarget, horizontalSpeed * Time.deltaTime);


            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                MoveRight();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                MoveLeft();
            }


            transform.position = pos;
            
        }
            anim.SetFloat("moveSpeed", Vector3.Magnitude(rb.velocity));

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
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            anim.SetBool("isJumping",true);
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

    public void SpeedUp() 
    {
        
        if (forwardSpeed < maxSpeed) forwardSpeed += speedMultiplier;

    }
}
