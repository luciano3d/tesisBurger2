using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 offset;
    public Transform referenceCamera;
    public Transform playerTransform;
    public bool playingPosition;
    private bool enterTransition;

    void Start()
    {
    }

    void Update()
    {
        if (GameManager.instance.isPlaying)
        {
            transform.position = Vector3.Lerp(transform.position, playerTransform.position+offset,10*Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, referenceCamera.rotation, Time.deltaTime * 10); 


        }
        if (enterTransition)
        {
            GameCameraTransition();
        }
    }

    private void GameCameraTransition() 
    {
        print(Vector3.Distance(transform.position, referenceCamera.position));
        if (Vector3.Distance(transform.position,referenceCamera.position) > 7f)
        {
            transform.position = Vector3.Lerp(transform.position, referenceCamera.position, Time.deltaTime * 1.25f); // velocidad de posicion

            Vector3 relativepos = playerTransform.position - transform.position;
            Quaternion lookrot = Quaternion.LookRotation(relativepos, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookrot, Time.deltaTime * 10f); //velocidad de rotacion

        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, playerTransform.position+offset, 1.25f *Time.deltaTime);
            if (Vector3.Distance(transform.rotation.eulerAngles, referenceCamera.rotation.eulerAngles) > .1f)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, referenceCamera.rotation, Time.deltaTime * 3);
                offset = referenceCamera.position - playerTransform.position;
            }
            else
            {
               // transform.position = referenceCamera.position;
                enterTransition = false;
                offset = referenceCamera.position - playerTransform.position;
                Invoke("StartGame", .05f);
            }
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
