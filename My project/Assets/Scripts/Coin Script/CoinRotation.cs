using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    public float rotateSpeed;
    public int reward = 1;
    private bool burgerPicked;
    void Start()
    {
    }

   
    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&& !burgerPicked)
        {
            GameManager.instance.CollectCoins(reward);
            burgerPicked = true;
            Destroy(gameObject);
        }
    }
}
