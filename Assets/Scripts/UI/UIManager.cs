using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject GameOverMenu;
    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject highScorePopup;
    public Text smallScore;
    public Text[] text = new Text[5];   // big score, gameOver, restart, mainMenu, quit

    private Color32 green = new Color32(0x22, 0x88, 0x22, 0xFF);
    private Color32 red = new Color32(0xFF, 0x00, 0x00, 0xFF);

    void Awake()
    {
        if(Instance == null){
            DontDestroyOnLoad(gameObject);
            Instance = this;
        } else if (Instance != this)
            Destroy(gameObject);
    }

    private void Start() {
        GameOverMenu.SetActive(false);
    }

    public void PlayGame(){
        PlayerScore.UpdateMultiplier();
        PlayerScore.playerScore = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        smallScore.enabled = true;
    }

    //TODO: Refactor, combine with win
    public void GameOverMenuUpdate(){
        GameOverMenu.SetActive(true);
        text[0].text = "Final Score: " + PlayerScore.playerScore;
        // if(!win){
        text[1].text = "Game Over!";
        foreach(Text t in text)
            t.color = red;
        // } else{
        //     text[1].text = "You Win!";
        //     foreach(Text t in text)
        //         t.color = green;
        // }
        if(FindObjectOfType<HighScoreMenu>().isHighScore()){
            highScorePopup.SetActive(true);
            FindObjectOfType<HighScoreMenu>().updateHighScore();
        }
    }

    public void WinMenuUpdate(){
        GameOverMenu.SetActive(true);
        text[0].text = "Final Score: " + PlayerScore.playerScore;
        text[1].text = "You Win!";
        foreach(Text t in text)
            t.color = green;
        FindObjectOfType<HighScoreMenu>().updateHighScore();
    }

    public void MainMenu(){
        SceneManager.LoadScene(0);
        mainMenu.SetActive(true);
        FindObjectOfType<gameManager>().isPlayerDead = false;
    }

    public void BackButton(){
        if(SceneManager.GetActiveScene().buildIndex == 0)
            mainMenu.SetActive(true);
        else
            pauseMenu.SetActive(true);
    }

    public void QuitGame(){
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
