using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundMixerManagerScript : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider MusicSlider;
    [SerializeField] private Slider SFXSlider;
    private void Start()
    {
        if (PlayerPrefs.HasKey("Music Volume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
            //SET INITIAL VOLUME TO 1
            MusicSlider.value = 1;
            SFXSlider.value = 1;
        }
    }

    public void SetMasterVolume(float volume)
    {
        //audioMixer.SetFloat("Master Volume",volume);
        audioMixer.SetFloat("Master Volumer", Mathf.Log10(volume) * 20f);
    }
    public void SetMusicVolume()
    {
        float volume = MusicSlider.value;
        //audioMixer.SetFloat("Music Volume",volume);
        audioMixer.SetFloat("Music Volume", Mathf.Log10(volume) * 20f);
        PlayerPrefs.SetFloat("Music Volume", volume);
    }
    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        //audioMixer.SetFloat("Sound Effects Volume", volume);
        audioMixer.SetFloat("Sound Effects Volume", Mathf.Log10(volume) * 20f);
        PlayerPrefs.SetFloat("Sound Effects Volume", volume);
    }
    public void LoadVolume()
    {
        MusicSlider.value = PlayerPrefs.GetFloat("Music Volume");
        SetMusicVolume();
        SFXSlider.value = PlayerPrefs.GetFloat("Sound Effects Volume");
        SetSFXVolume();
        
    }
}
