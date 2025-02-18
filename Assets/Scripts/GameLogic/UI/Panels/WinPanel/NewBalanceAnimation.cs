using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewBalanceAnimation : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] float _duration;
    [SerializeField] Ease _ease;

    [Space]
    [SerializeField] Transform _parentToSpawnNewText;
    [SerializeField] GameObject _text;

    GameObject _textToAnimate;

    public static Action<float> onNewBalanceEndAnimation;

    public void Animate() {
        _textToAnimate = Instantiate(_text, _parentToSpawnNewText);
        _textToAnimate.transform.DOMove(_target.position, _duration).SetEase(_ease);
        onNewBalanceEndAnimation?.Invoke(_duration);
        Destroy(_textToAnimate, _duration);
    }
}
