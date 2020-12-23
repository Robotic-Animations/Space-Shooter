using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    public gameManager GameManager;
    public GameObject highScorePopup;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)){
            if(FindObjectOfType<UIManager>().GameOverMenu.activeSelf && !highScorePopup.activeSelf)
                GameManager.Restart();
        }
    }
}
