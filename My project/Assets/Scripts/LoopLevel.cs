using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopLevel : MonoBehaviour
{
    public Transform player;

    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.z < player.position.z && Vector3.Distance(transform.position,player.position)>75)
        {
            Vector3 pos = new Vector3(0,0, GameManager.instance.forwardCityPosition + 114.45f);
            transform.position = pos;
            GameManager.instance.forwardCityPosition = pos.z;
        }
    }
}
