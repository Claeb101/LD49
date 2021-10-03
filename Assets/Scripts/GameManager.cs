using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isPlaying = true;

    public GameObject endGameCanvas;

    private void OnGUI()
    {
        Debug.Log("sorting visually");
        SortSprites();
    }

    // Start is called before the first frame update
    void Start()
    {
        endGameCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SortSprites();
    }

    void SortSprites()
    {
        foreach (var sprite in FindObjectsOfType<SpriteRenderer>())
        {
            if (sprite.sortingLayerName.Equals("Middleground"))
            {
                sprite.sortingOrder = (int)(1000f * -sprite.transform.position.y);
            }
        }
    }

    public void OnExit()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnLose()
    {
        Debug.Log("dead");
        isPlaying = false;
        
        endGameCanvas.SetActive(true);
    }

    public void OnReplay()
    {
        SceneManager.LoadScene("Game");
    }
}