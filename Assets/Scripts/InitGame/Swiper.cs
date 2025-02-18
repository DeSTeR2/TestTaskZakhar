using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Swiper : MonoBehaviour {
    public UnityEvent _event;
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            _event.Invoke();
        }
    }
}