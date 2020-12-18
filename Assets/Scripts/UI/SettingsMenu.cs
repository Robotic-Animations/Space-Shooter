using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject pauseMenu;
    public AudioMixer audioMixer;

    public void SetVolume(float volume){
        Debug.Log("volume: " + volume);
        audioMixer.SetFloat("volume", volume);
    }

    public void SetFullscreen(bool isFullScreen){
        Debug.Log("toggle fullscreen");
        Screen.fullScreen = isFullScreen;
    }

    public void SetDifficulty(int difficultyIndex){
        switch(difficultyIndex){
            case 0:
                Debug.Log("easy difficulty");
                // enemyController.fireRate = 0.002f;
                // enemyController.speed = 0.7f;
                break;
            case 1:
                Debug.Log("normal difficulty");
                // enemyController.fireRate = .004f;
                // enemyController.speed = 1f;
                break;
            case 2:
                Debug.Log("hard difficulty");
                // enemyController.fireRate = .01f;
                // enemyController.speed = 1.2f;
                break;
        }
    }

    public void BackButton(){
        if(SceneManager.GetActiveScene().buildIndex == 0)
            mainMenu.SetActive(true);
        else
            pauseMenu.SetActive(true);
    }
}
