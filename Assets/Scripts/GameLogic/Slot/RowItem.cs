using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class RowItem : MonoBehaviour
{
    [SerializeField] Tiles _tiles;

    [Header("Settings")]
    [SerializeField] SingleRotationTile[] _rotationTiles;
    [SerializeField] float _duration;
    [SerializeField, Range(0, 0.5f)] float _maxDirationOffset;

    [SerializeField] Ease _animationEase;
    [SerializeField] int _minRotationTimes;
    [SerializeField] int _maxRotationTimes;
    [SerializeField] Transform _rotationTarget;
    [SerializeField] Transform _startRotationTarget;

    [Space]
    [SerializeField] float upperPadding = 5;

    public static Action onRowItemRotated;

    private Transform[] _imagePositions = new Transform[3];
    float defDuratrion;

    private void Awake() {
        defDuratrion = _duration;

        float imageHeight = _rotationTiles[0].transform.gameObject.GetComponent<RectTransform>().sizeDelta.y + upperPadding;

        int number = -1;
        for (int i=0; i< _rotationTiles.Length; i++) {
            _rotationTiles[i].SetUp();

            Vector3 pos = _rotationTiles[i].transform.localPosition;
            pos += new Vector3(0, imageHeight * number, 0);
            _rotationTiles[i].transform.localPosition = pos;


            number++;
        }

        for (int i=0; i < _rotationTiles.Length; i++) {
            GenerateNewSprite(i);
        }

        _rotationTarget.position = _rotationTiles[0].transform.position;
        _startRotationTarget.position = _rotationTiles[2].transform.position;
    }

    public void AnimateRotationTiles() { 
        int rotationTimes = UnityEngine.Random.Range(_minRotationTimes, _maxRotationTimes+1);

        float durationOffset = UnityEngine.Random.Range(-_maxDirationOffset, _maxDirationOffset);
        _duration += durationOffset;

        StartCoroutine(Spin(rotationTimes));
    }

    private IEnumerator Spin(int rotationTimes) {

        List<Sequence> sequences = new List<Sequence>();

        for (int i = 0; i < _rotationTiles.Length; i++) {
            if (_imagePositions[i] == null) {
                _imagePositions[i] = _rotationTiles[i].transform;
            }

            Sequence imageSequence = DOTween.Sequence();
            if (i - 1 >= 0) {
                Vector3 target = _rotationTiles[i-1].transform.localPosition;
                imageSequence.Append(_rotationTiles[i].transform.DOLocalMove(target, _duration).SetEase(_animationEase));
            } else {
                Vector3 target = _rotationTiles[^1].transform.localPosition;
                imageSequence.Append(_rotationTiles[i].transform.DOLocalMove(target, _duration).SetEase(_animationEase));
            }
            sequences.Add(imageSequence);
        }

        for (int i=0; i<sequences.Count; i++) {
            if (Vector3.Distance(_rotationTiles[i].transform.localPosition, _rotationTarget.localPosition) < 0.1f) {
                _rotationTiles[i].transform.localPosition = _startRotationTarget.localPosition;
                GenerateNewSprite(i);
                continue;
            }

            sequences[i].Play();
        }
        yield return new WaitWhile(sequences[0].IsPlaying);

        if (rotationTimes - 1 > 0)
            StartCoroutine(Spin(--rotationTimes));
        else {
            _duration = defDuratrion;
            onRowItemRotated?.Invoke();
        }
    }

    private void GenerateNewSprite(int i) {
        _rotationTiles[i].NewTileInfo(_tiles.GetSingleTile());
    }

    public SingleRotationTile GetRotatedTile() {
        for (int i=0; i<_rotationTiles.Length; i++) {
            if (Vector3.Distance(Vector3.zero, _rotationTiles[i].transform.localPosition) < 0.1f) {
                return _rotationTiles[i];
            }
        }
        return null;
    }

}
