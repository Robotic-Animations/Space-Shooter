using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;

public class HighScoreMenu : MonoBehaviour
{
    public InputField inputField;
    public Button okButton;

    public Dictionary<int, string> highScores = new Dictionary<int, string>();
    public Text[] highScoresText = new Text[6];
    public Text[] namesText = new Text[6];

    void Start()
    {
        Button btn = okButton.GetComponent<Button>();
        btn.onClick.AddListener(updateHighScore);

        setHighScoreText();
    }

    void setHighScoreText(){
        int[] scores = PlayerPrefsX.GetIntArray("HighScores");
        string[] names = PlayerPrefsX.GetStringArray("HighScoreNames");
        if(scores == null || scores.Length == 0)
            return;
        else{
            string[] savedScores = Array.ConvertAll(scores, x=>x.ToString());
            for(int i = 0; i < savedScores.Length; i++){
                if(savedScores[i] == "0")
                    highScoresText[i].text = string.Empty;
                else
                    highScoresText[i].text = savedScores[i];
            }
            for(int i = 0; i < names.Length; i++)
                namesText[i].text = names[i];
        }
    }

    public bool isHighScore(){
        int[] highScores = PlayerPrefsX.GetIntArray("HighScores");
        if(highScores == null || highScores.Length == 0 || PlayerScore.playerScore > highScores[highScores.Length - 1])
            return true;
        else
            return false;
    }

    public string setName(){
        Debug.Log(inputField.text);
        return inputField.text;
    }

    void insertHighScore(){
        int[] scores = PlayerPrefsX.GetIntArray("HighScores");
        string[] names = PlayerPrefsX.GetStringArray("HighScoreNames");

        if(scores == null || scores.Length == 0){
            int[] firstScore = new int[6];
            string[] firstName = new string[6];
            for(int i = 0; i < firstName.Length; i++)
                firstName[i] = string.Empty;

            firstScore[0] = PlayerScore.playerScore;
            firstName[0] = setName();
            PlayerPrefsX.SetIntArray("HighScores", firstScore);
            PlayerPrefsX.SetStringArray("HighScoreNames", firstName);
        } else{
            if(isHighScore()){
                int pos = 1;
                foreach(int s in scores){
                    if(PlayerScore.playerScore > s){
                        pos = Array.IndexOf(scores, s);
                        break;
                    }
                }

                for(int i = scores.Length - 1; i > pos; i--){
                    scores[i] = scores[i-1];
                    names[i] = names[i-1];
                }
                scores[pos] = PlayerScore.playerScore;
                names[pos] = setName();

                PlayerPrefsX.SetIntArray("HighScores", scores);
                PlayerPrefsX.SetStringArray("HighScoreNames", names);
            }
        }
    }

    public void updateHighScore(){
        insertHighScore();
        setHighScoreText();
    }

    public void resetHighScore(){
        // TODO: set empty strings
        PlayerPrefs.DeleteAll();
        foreach(Text hs in highScoresText)
            hs.text = string.Empty;
        foreach(Text n in namesText)
            n.text = string.Empty;
    }
}
