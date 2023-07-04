using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    public Transform referenceCamera;
    public Transform playerTransform;
    public bool playingPosition;
    private bool enterTransition;

    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offset.z + target.position.z);
        //transform.position = Vector3.Lerp(transform.position,target.position+offset,10*Time.deltaTime);
        
        if (GameManager.instance.isPlaying)
        {
            transform.position = Vector3.Lerp(transform.position,target.position+offset,10*Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, referenceCamera.rotation, Time.deltaTime * 10); 


        }
        if (enterTransition)
        {
            GameCameraTransition();
        }
    }

    private void GameCameraTransition() 
    {
        
        if (Vector3.Distance(transform.position,referenceCamera.position)>.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, referenceCamera.position, Time.deltaTime * 10); // velocidad de posicion
            Vector3 relativepos = playerTransform.position - transform.position;
            Quaternion lookrot = Quaternion.LookRotation(relativepos, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookrot, Time.deltaTime * 10); //velocidad de rotacion
        }
        else
        {
            transform.position = referenceCamera.position;
            enterTransition = false;
            offset = transform.position - target.position;
            Invoke("StartGame", .12f);
        }
    }

    public void StartTransition() 
    {
        enterTransition = true;
    }

    private void StartGame() 
    {
        GameManager.instance.isPlaying = true;
    }

}
