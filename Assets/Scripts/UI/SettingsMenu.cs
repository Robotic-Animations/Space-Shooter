using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject pauseMenu;
    public AudioMixer audioMixer;

    public Dropdown difficultyDropdown;
    public Toggle fullScreenToggle;

    void Start() {
        difficultyDropdown.value = 1;
        if(Screen.fullScreen)
            fullScreenToggle.isOn = true;
        else
            fullScreenToggle.isOn = false;
    }

    public void SetVolume(float volume){
        audioMixer.SetFloat("volume", volume);
    }

    public void SetFullScreen(bool isFullScreen){
        Screen.fullScreen = isFullScreen;
    }

    public void BackButton(){
        if(SceneManager.GetActiveScene().buildIndex == 0)
            mainMenu.SetActive(true);
        else
            pauseMenu.SetActive(true);
    }
}
