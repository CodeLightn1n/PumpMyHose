using UnityEngine;
using UnityEngine.UI;

/*
    THIS IS A APA7TH SCRIPT/CODE from https://uark.libguides.com/CSCE/CitingCode
Title: AudioManager
Aurther: Greg Eads
Date: <2019>
Availability https://youtu.be/9ROolmPSC70
*/


public class AudioManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    private int firstPlayInt;
    public Slider backgroundSlider, soundEffectSlider;
    private float backgroundFloat, soundEffectsFloat;
    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectsAudio;

    void Start() 
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if(firstPlayInt == 0)
        {
            backgroundFloat =.25f;
            soundEffectsFloat =.75f;
            backgroundSlider.value = backgroundFloat;
            soundEffectSlider.value = soundEffectsFloat;
            PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);
            PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
            
        }
        else
        {
            backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
            backgroundSlider.value = backgroundFloat;
            soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);
            soundEffectSlider.value = soundEffectsFloat;
        }

    }


    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(BackgroundPref, backgroundSlider.value);
        PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectSlider.value);
    }

    /// <summary>
    /// Detecting if the player has closed, minimized or paused the game it will save the values
    /// </summary>
    void OnApllicationFocus(bool inFocus)
    {
        if(!inFocus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound()
    {
        backgroundAudio.volume = backgroundSlider.value;

        for(int i = 0; i < soundEffectsAudio.Length; i++ )//Have many value in that array
        {
            soundEffectsAudio[i].volume = soundEffectSlider.value;
        }
    }

}
