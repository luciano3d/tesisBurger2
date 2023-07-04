using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isPlaying;
    public float forwardCityPosition = 245.4f;
    private int coins;
    public TextMeshProUGUI txtCoins;
    private float passedTime;
    public float limitedTime = 200;
    private PlayerController playerControl;
    void Awake()
    {
        instance = this;
        coins = 0;
        txtCoins.text = coins.ToString();
        playerControl = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        
        if (isPlaying) SpeedUp();
       
    }

    public void CollectCoins(int reward) 
    {
        coins+=reward;

        txtCoins.text = coins.ToString();
    }

    public void RestartLevel() 
    {
        SceneManager.LoadScene("GameScene");
    }

    private void SpeedUp()
    {
        passedTime += Time.deltaTime;
        if (passedTime >= limitedTime)
        {
            print("speed up");
            passedTime = 0;
            playerControl.SpeedUp();
        }
    }
    
}
