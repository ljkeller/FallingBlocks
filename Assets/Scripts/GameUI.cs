using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public GameObject gameOverScreen;

    public GameObject gamePlayScreen;

    public Text scoreUI;

    public Text activeScore;
    PlayerController player;

    bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        player.onPointEarned += onPointEarned;
        activeScore.text = "0";
        player.onPlayerDeath += GameOver;

        gameOverScreen.SetActive(false);
        gamePlayScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space)) //Want to reload scene then, so import UnityEngine.SceneManagement
            {
                gameOver = false;
                SceneManager.LoadScene(0); //Can load name or index
            }
        } 
    }

    void onPointEarned()
    {
        activeScore.text = player.score.ToString();
    }

    void GameOver()
    {
        gamePlayScreen.SetActive(false);
        gameOverScreen.SetActive(true); //Enables object, but need UnityEngine.UI to modify score
        scoreUI.text = player.score.ToString();
        gameOver = true;
    }
}
