using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecolectLetters : MonoBehaviour
{
    public int letterID;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LetterManager.instance.RecolectedLetter(letterID);
            Destroy(gameObject);
        }
    }
}
