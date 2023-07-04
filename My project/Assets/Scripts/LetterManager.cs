using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LetterManager : MonoBehaviour
{
    private bool[] LetterStatus = new bool[5];
    public GameObject[] LetterHud;
    public static LetterManager instance;
    public Image panelFade;
    public float transitionSpeed;
    private bool allCollectedLetters;
    void Awake()
    {
        instance = this;
    }

    public void RecolectedLetter(int letterID)
    {
        if (!allCollectedLetters)
        {
            LetterStatus[letterID] = true;
            LetterHud[letterID].SetActive(true);
            for (int i = 0; i < LetterStatus.Length; i++)
            {
                if (LetterStatus[i] == false)
                {
                    return;
                }
            }
            allCollectedLetters = true;
            StartCoroutine(SceneTransition());
        }
        
    }

    

    private IEnumerator SceneTransition()
    {
        print("All letters collected");
        GameManager.instance.isPlaying = false;
        Color fadeColor = panelFade.color;
        while (fadeColor.a <1)
        {
            fadeColor.a += Time.deltaTime * transitionSpeed;
            panelFade.color = fadeColor;
            yield return null;
        }
        SceneManager.LoadScene(1);
    }


}
