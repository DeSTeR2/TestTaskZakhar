using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigWinCointAnimation : MonoBehaviour
{
    [Header("Animation settings")]
    [SerializeField] float _duration;
    [SerializeField] float _startScale;
    [SerializeField] Ease _scaleEase;

    private void OnEnable() {
        gameObject.transform.DOScale(_startScale, 0);
        gameObject.transform.DOScale(1, _duration).SetEase(_scaleEase);
    }
}
