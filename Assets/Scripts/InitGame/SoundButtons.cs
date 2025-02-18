using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButtons : MonoBehaviour {
    [SerializeField] GameObject _on;
    [SerializeField] GameObject _off;
    [SerializeField] string _soundSave = "Sound";

    private void Start() {
        int sound = PlayerPrefs.GetInt(_soundSave);
        if (sound == 0) {
            _on.SetActive(true);
            _off.SetActive(false);
        } else {
            _on.SetActive(false);
            _off.SetActive(true);
        }
    }
}
