using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Blur : MonoBehaviour
{
    PostProcessVolume postProcessVolume;

    public static Blur Instance;

    private void Awake() {
        Instance = this;
        postProcessVolume = GetComponent<PostProcessVolume>();
        postProcessVolume.weight = 0;
    }

    public void BlurCamera() {
        postProcessVolume.weight = 1;
    }

    public void UnBlurCamera() {
        postProcessVolume.weight = 0;
    }


}
