using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance;
    public bool isPlayerDead = false;

    void Awake(){
        if(Instance == null){
            DontDestroyOnLoad(gameObject);
            Instance = this;
        } else if(Instance != this)
            Destroy(gameObject);
    }

    public void GameOver(){
        if(isPlayerDead == false){
            isPlayerDead = true;
            Time.timeScale = 0;
            FindObjectOfType<UIManager>().GameOverMenuUpdate();
        }
    }

    public void Win(){
        Time.timeScale = 0;
        FindObjectOfType<UIManager>().WinMenuUpdate();
        FindObjectOfType<AudioManager>().Play("win");
    }

    //TODO: should this be in UIManager
    public void Restart(){
        PlayerScore.playerScore = 0;
        isPlayerDead = false;
        FindObjectOfType<UIManager>().GameOverMenu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
