using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalutAnimation : MonoBehaviour
{
    [Header("Animation settings")]
    [SerializeField] float _duration;
    [SerializeField] Vector3 _rotation;
    [SerializeField] float _startScale;
    [SerializeField] Ease _scaleEase;
    [SerializeField] Ease _rotationEase;

    List<GameObject> _salut = new List<GameObject>();

    private void Awake() {
        for (int i = 0; i < transform.childCount; i++) {
            _salut.Add(transform.GetChild(i).gameObject);
        }
    }

    private void OnEnable() {
        for (int i = 0; i < _salut.Count; i++) {
            _salut[i].transform.DOScale(_startScale, 0);
            _salut[i].transform.rotation = Quaternion.identity;
        }

        for (int i = 0; i < _salut.Count; i++) {
            _salut[i].transform.DORotate(_rotation, _duration).SetEase(_rotationEase).SetLoops(-1, LoopType.Yoyo);
            _salut[i].transform.DOScale(1, _duration).SetEase(_scaleEase);
        }
    }
}
