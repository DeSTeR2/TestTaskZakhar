using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanel : MonoBehaviour
{
    private void OnEnable() {
        if (Blur.Instance != null)
            Blur.Instance.BlurCamera();
    }

    private void OnDisable() {
        if (Blur.Instance != null)
            Blur.Instance.UnBlurCamera();
    }

}
