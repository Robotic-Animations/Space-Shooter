using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;

public class SettingsMenu : MonoBehaviour
{
    private const float MUTE_LEVEL = -40f;
    private const float MAX_VOLUME = 100f;
    private const float MIN_VOLUME = 0f;

    //TODO: refactor audio stuff
    [SerializeField] AudioMixerGroup masterMixer = null;
    [SerializeField] AudioMixerGroup soundsMixer = null;
    [SerializeField] AudioMixerGroup musicMixer = null;

    [SerializeField] Text masterVolumeValue = null;
    [SerializeField] Text soundsVolumeValue = null;
    [SerializeField] Text musicVolumeValue = null;
    [SerializeField] Slider masterVolumeSlider = null;
    [SerializeField] Slider soundsVolumeSlider = null;
    [SerializeField] Slider musicVolumeSlider = null;

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

    public void SetMasterVolume(float masterVolume){
        //TODO: AudioMixer.SetFloat("exposedVolumeParam", Mathf.Log10(sliderValueGoesHere) *20);
        masterMixer.audioMixer.SetFloat("masterVolume", masterVolume);
        mute(masterMixer, masterVolume, "masterVolume");
        masterVolumeValue.text = map(masterVolumeSlider, masterVolume).ToString();
    }

    public void SetSoundsVolume(float soundsVolume){
        soundsMixer.audioMixer.SetFloat("soundsVolume", soundsVolume);
        mute(soundsMixer, soundsVolume, "soundsVolume");
        soundsVolumeValue.text = map(soundsVolumeSlider, soundsVolume).ToString();
    }

    public void SetMusicVolume(float musicVolume){
        musicMixer.audioMixer.SetFloat("musicVolume", musicVolume);
        mute(musicMixer, musicVolume, "musicVolume");
        musicVolumeValue.text = map(musicVolumeSlider, musicVolume).ToString();
    }

    public void SetFullScreen(bool isFullScreen){
        Screen.fullScreen = isFullScreen;
    }

    private int map(Slider slider, float input){
        // map the audio mixer level (dB) to 0-100 on the slider
        float m = (MAX_VOLUME - MIN_VOLUME) / (slider.maxValue - slider.minValue);
        float b = MAX_VOLUME;
        return (int)Math.Round(m * input + b);
    }

    private void mute(AudioMixerGroup mixer, float volume, string v){
        // mute the volume if below a threshold
        if(volume <= MUTE_LEVEL)
            mixer.audioMixer.SetFloat(v, -80f);
    }
}
