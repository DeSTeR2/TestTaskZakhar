using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAnimation : MonoBehaviour {
    [Header("Animation settings")]
    [SerializeField] float _duration;
    [SerializeField] Vector3 _rotation;
    [SerializeField] float _startScale;
    [SerializeField] Ease _scaleEase;
    [SerializeField] Ease _rotationEase;
    [SerializeField, Range(2, 6)] int _rotationLoops;

    List<GameObject> _stars = new List<GameObject> ();

    private void Awake() {
        for (int i=0; i < transform.childCount; i++) {
            _stars.Add (transform.GetChild(i).gameObject);
        }
    }

    private void OnEnable() {
        for (int i = 0; i < _stars.Count; i++) {
            _stars[i].transform.DOScale(_startScale, 0);
            _stars[i].transform.rotation = Quaternion.identity;
        }

        StartCoroutine(StarAnimation());


        IEnumerator StarAnimation() {
            for (int i = 0; i < _stars.Count; i++) {
                _stars[i].transform.DORotate(_rotation, _duration, RotateMode.FastBeyond360).SetEase(_rotationEase);
                _stars[i].transform.DOScale(1, _duration).SetEase(_scaleEase);
                
                yield return null;
            }
        }
    }
}
