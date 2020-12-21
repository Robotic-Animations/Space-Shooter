using UnityEngine;
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
        Time.timeScale = 0;
        gameIsPaused = true;
        pauseMenu.SetActive(true);
        smallScore.enabled = false;
        largeScore.text = "Current Score: " + PlayerScore.playerScore;
    }

    public void Resume(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
        smallScore.enabled = true;
    }

    public void Restart(){
        GameManager.Restart();
        gameIsPaused = false;
        smallScore.enabled = true;
    }

    public void MainMenu(){
        //TODO: small score bug
        smallScore.enabled = true;
        FindObjectOfType<UIManager>().MainMenu();
        gameIsPaused = false;
    }
}
