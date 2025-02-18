using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {
    [SerializeField] AudioSource sound;
    [SerializeField] AudioSource music;

    [Header("Sound")]
    [SerializeField] AudioClip _bigWin;
    [SerializeField] AudioClip _coinRain;
    [SerializeField] AudioClip _buttonClick;
    [SerializeField] AudioClip _newLevel;


    [Space]
    [SerializeField] string _soundSave = "Sound";
    [SerializeField] string _musicSave = "Music";
    [SerializeField] string _soundPlaySave = "SoundOn";

    public static float soundVolume { get; private set; }
    public static float musicVolume { get; private set; }

    public static SoundManager instance;

    private void Awake() {

        //if (instance == null) {
            instance = this;
        //    DontDestroyOnLoad(this.gameObject);
        //}
        //else {
        //    if (instance != this) {
        //        Destroy(this.gameObject);
        //    }
        //}
    }

    private void OnEnable() {
        soundVolume = PlayerPrefs.GetFloat(_soundSave, 1);
        musicVolume = PlayerPrefs.GetFloat(_musicSave, 1);

        sound.volume = soundVolume;
        music.volume = musicVolume;
    }

    public void ChangeSoundVolume(Slider slider) {
        soundVolume = slider.value;
        sound.volume = soundVolume;

        PlayerPrefs.SetFloat(_soundSave, soundVolume);
        PlayerPrefs.Save();
    }

    public void ChangeMusicVolume(Slider slider) {
        musicVolume = slider.value;
        music.volume = musicVolume;

        PlayerPrefs.SetFloat(_musicSave, musicVolume);
        PlayerPrefs.Save();
    }

    public void SetMute() {
        PlayerPrefs.SetInt(_soundPlaySave, 1);
        PlayerPrefs.Save();
        Mute();
    }

    public void SetUnMute() {
        PlayerPrefs.SetInt(_soundPlaySave, 0);
        PlayerPrefs.Save();
        UnMute();
    }

    public void Mute() {
        sound.volume = 0;
        music.volume = 0;
    }

    public void UnMute() {
        sound.volume = soundVolume;
        music.volume = musicVolume;
    }

    public void BigWin() {
        sound.PlayOneShot(_bigWin);
        sound.PlayOneShot(_coinRain);
    }

    public void NewLevel() {
        sound.PlayOneShot(_newLevel);
    }

    public void ButtonClick() {
        sound.PlayOneShot(_buttonClick);
    }

}