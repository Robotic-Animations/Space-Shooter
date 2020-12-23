using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] AudioMixerGroup masterMixer = null;
    [SerializeField] AudioMixerGroup soundsMixer = null;
    [SerializeField] AudioMixerGroup musicMixer = null;

    [SerializeField] Text masterVolumeValue = null;
    [SerializeField] Text soundsVolumeValue = null;
    [SerializeField] Text musicVolumeValue = null;

    public Toggle fullScreenToggle;
    public Dropdown difficultyDropdown;

    void Start() {
        if(Screen.fullScreen)
            fullScreenToggle.isOn = true;
        else
            fullScreenToggle.isOn = false;

        //TODO: save/load between sessions
        masterVolumeValue.text = soundsVolumeValue.text = musicVolumeValue.text = "100";

        difficultyDropdown.value = 1;
    }

    public void SetFullScreen(bool isFullScreen){
        Screen.fullScreen = isFullScreen;
    }

    public void SetMasterVolume(float masterVolume){
        masterMixer.audioMixer.SetFloat("masterVolume", Mathf.Log10(masterVolume) * 20);
        masterVolumeValue.text = ((int)Math.Round(masterVolume * 100)).ToString();
    }

    public void SetSoundsVolume(float soundsVolume){
        soundsMixer.audioMixer.SetFloat("soundsVolume", Mathf.Log10(soundsVolume) * 20);
        soundsVolumeValue.text = ((int)Math.Round(soundsVolume * 100)).ToString();
    }

    public void SetMusicVolume(float musicVolume){
        musicMixer.audioMixer.SetFloat("musicVolume", Mathf.Log10(musicVolume) * 20);
        musicVolumeValue.text = ((int)Math.Round(musicVolume * 100)).ToString();
    }
}
