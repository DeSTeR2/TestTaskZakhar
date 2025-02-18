using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SingleCoin : MonoBehaviour
{
    [SerializeField] float _duration;
    [SerializeField] Ease _ease;

    Image _image;
    Vector3 _target;

    private void Awake() {
        _image = GetComponent<Image>();
    }
    private void OnEnable() {
        _target = transform.position;
        _target.y -= Screen.height + Screen.height*0.5f;

    }
    public void Init(Sprite sprite) {
        _image.sprite = sprite;
        _image.SetNativeSize();

        transform.DOMove(_target, _duration).SetEase(_ease);
    }
}
