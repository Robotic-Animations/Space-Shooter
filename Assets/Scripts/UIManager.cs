using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject GameOverMenu;
    public GameObject mainMenu;
    public Text[] text = new Text[5];   // score, gameOver, restart, mainMenu, quit

    private Color32 green = new Color32(0x22, 0x88, 0x22, 0xFF);

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
        Debug.Log("start game");
        PlayerScore.playerScore = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        text[0].enabled = true;
    }

    public void GameOverMenuUpdate(){
        GameOverMenu.SetActive(true);
        text[0].text = "Final Score: " + PlayerScore.playerScore;
        text[1].text = "Game Over!";
    }

    public void WinMenuUpdate(){
        GameOverMenu.SetActive(true);
        text[0].text = "Final Score: " + PlayerScore.playerScore;
        text[1].text = "You Win!";
        foreach(Text t in text){
            t.color = green;
        }
    }

    public void Restart(){
        GameOverMenu.SetActive(false);
    }

    public void OpenSettings(){
        Debug.Log("settings");
    }

    public void MainMenu(){
        Debug.Log("main menu");
        SceneManager.LoadScene(0);
        mainMenu.SetActive(true);
        FindObjectOfType<gameManager>().isPlayerDead = false;
    }

    public void QuitGame(){
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
