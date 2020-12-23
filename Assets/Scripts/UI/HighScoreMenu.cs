using UnityEngine;
using UnityEngine.UI;
using System;

public class HighScoreMenu : MonoBehaviour
{
    public Text[] highScores = new Text[6];
    public Text[] names = new Text[6];

    void Start()
    {
        setHighScoreText();
    }

    void setHighScoreText(){
        if(PlayerPrefsX.GetIntArray("HighScores") == null || PlayerPrefsX.GetIntArray("HighScores").Length == 0)
            return;
        else{
            String[] str_arr = Array.ConvertAll(PlayerPrefsX.GetIntArray("HighScores"), x=>x.ToString());
            for(int i=0; i<str_arr.Length; i++)
                highScores[i].text = str_arr[i];
        }
    }

    // public String setHighScoreName(String nameText){
    //     return nameText;
    // }

    // void setNames(){
        
    // }

    void insertHighScore(){
        int[] scores = PlayerPrefsX.GetIntArray("HighScores");

        if(PlayerPrefsX.GetIntArray("HighScores") == null || PlayerPrefsX.GetIntArray("HighScores").Length == 0){
            int[] firstScore = new int[6];
            firstScore[0] = PlayerScore.playerScore;
            PlayerPrefsX.SetIntArray("HighScores", firstScore);
        } else{
            if(isHighScore()){
                int pos = 1;
                foreach(int s in scores){
                    if(PlayerScore.playerScore > s){
                        pos = Array.IndexOf(scores, s);
                        break;
                    }
                }

                for(int i = scores.Length - 1; i > pos; i--)
                    scores[i] = scores[i-1];
                scores[pos] = PlayerScore.playerScore;

                PlayerPrefsX.SetIntArray("HighScores", scores);
            }
        }
    }

    public void updateHighScore(){
        insertHighScore();
        setHighScoreText();
    }

    public bool isHighScore(){
        int[] highScores = PlayerPrefsX.GetIntArray("HighScores");
        if(highScores == null || highScores.Length == 0 || PlayerScore.playerScore > highScores[highScores.Length - 1])
            return true;
        else
            return false;
    }

    public void resetHighScore(){
        PlayerPrefs.DeleteAll();
        foreach(Text hs in highScores)
            hs.text = "0";
    }
}
