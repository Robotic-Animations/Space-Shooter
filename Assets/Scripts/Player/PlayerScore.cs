using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public static int playerScore = 0;
    public static int scoreMultiplier = 2;
    private Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    void Update()
    {
        scoreText.text = "Score: " + playerScore;
    }

    public static void UpdateMultiplier(){
        switch(FindObjectOfType<SettingsMenu>().difficultyDropdown.value){
            case 0:
                scoreMultiplier = 1;
                break;
            case 1:
                scoreMultiplier = 2;
                break;
            case 2:
                scoreMultiplier = 4;
                break;
            case 3:
                scoreMultiplier = 10;
                break;
            default:
                scoreMultiplier = 2;
                break;
        }
    }
}
