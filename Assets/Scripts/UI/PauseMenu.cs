﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenu;
    public gameManager GameManager;
    public GameObject settingsMenu;
    public Text smallScore;
    public Text largeScore;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(gameIsPaused){
                if(!settingsMenu.activeSelf)
                    Resume();
            }
            else{
                if(Time.timeScale == 1 && SceneManager.GetActiveScene().buildIndex != 0)
                    Pause();
            }
        }
    }

    void Pause(){
        Debug.Log("pause game");
        Time.timeScale = 0;
        gameIsPaused = true;
        pauseMenu.SetActive(true);
        smallScore.enabled = false;
        largeScore.text = "Current Score: " + PlayerScore.playerScore;
    }

    public void Resume(){
        Debug.Log("resume game");
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
        smallScore.enabled = true;
    }

    public void Restart(){
        Debug.Log("restart level");
        GameManager.Restart();
        gameIsPaused = false;
        smallScore.enabled = true;
    }

    public void MainMenu(){
        smallScore.enabled = true;
        FindObjectOfType<UIManager>().MainMenu();
        gameIsPaused = false;
    }
}
