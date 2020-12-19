using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    public gameManager GameManager;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)){
            if(FindObjectOfType<UIManager>().GameOverMenu.activeSelf)
                GameManager.Restart();
        }
    }
}
