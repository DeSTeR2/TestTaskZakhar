using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField] string _soundSave;
    [SerializeField] GameObject _on;
    [SerializeField] GameObject _off;
    private void Start() {
        if (PlayerPrefs.GetInt(_soundSave, 0) == 0) {
            _on.SetActive(true);
            _off.SetActive(false);
        } else {
            _on.SetActive(false);
            _off.SetActive(true);
        }
    }

}
