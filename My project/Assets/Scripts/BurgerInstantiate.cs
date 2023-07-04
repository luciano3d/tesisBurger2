using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BurgerInstantiate : MonoBehaviour
{
    public GameObject burgerPrefab;
    [Tooltip("distancia de separación en Z")]public float separationZ;
    public int maxBurgers;
    public Vector3 spawnPos;
    public Image panelFade;
    public float transitionSpeed;
    public GameObject levelLimit;
    void Start()
    {
        SpawnBurger();
        StartCoroutine(SceneTransition());
    }

  
    private void SpawnBurger()
    {
        for (int i = 0; i < maxBurgers; i++)
        {
            switch (Random.Range(0,3))
            {
                case 0:
                    spawnPos.x -= 4.22f;
                    if (spawnPos.x < -4.22f)
                    {
                        spawnPos.x = -4.22f;
                    }
                    break;
                case 2:
                    spawnPos.x += 4.22f;
                    if (spawnPos.x > 4.22f)
                    {
                        spawnPos.x = 4.22f;
                    }
                    break;
                default:
                    break;
            }
            Instantiate(burgerPrefab, spawnPos, Quaternion.identity);
            spawnPos.z += separationZ;

        }
        spawnPos.x = 0;
        spawnPos.z += separationZ * 3;
        levelLimit.transform.position = spawnPos;
    }

    private IEnumerator SceneTransition()
    {
        
        Color fadeColor = Color.black;
        while (fadeColor.a > 0)
        {
            fadeColor.a -= Time.deltaTime * transitionSpeed;
            panelFade.color = fadeColor;
            yield return null;
        }
    }
}
