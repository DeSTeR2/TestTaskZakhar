using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour {
    [SerializeField] Slider _music;
    [SerializeField] Slider _sound;

    private void Start() {
        _music.value = SoundManager.musicVolume;
        _sound.value = SoundManager.soundVolume;
    }
}
