using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Vector2 firstPressPos;
    private Vector2 secondPressPos;
    private Vector2 currentSwipe;
    public PlayerController playerScript;
    public CameraController controlCamera;
    public GameObject txtStart;
    public GameObject txtHands;
    private bool gameStarted;

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!gameStarted)
            {
                gameStarted = true;
                txtStart.SetActive(false);
                txtHands.SetActive(false);
                //GameManager.instance.isPlaying = true;
                controlCamera.StartTransition();

            }
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        }
        //mouse Input
        SwipeDetection();

        //teclado input
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerScript.MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerScript.MoveLeft();
        }
    }

    public void SwipeDetection()
    {
       
        if (GameManager.instance.isPlaying && Input.GetMouseButtonUp(0))
        {
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            currentSwipe.Normalize();

            //swipe upwards
            if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
               
                playerScript.Jump();

            }
            //swipe down
            if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
               
            }
            //swipe left
            if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                
                playerScript.MoveLeft();
            }
            //swipe right
            if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                
                playerScript.MoveRight();
            }
        }
    }
}
