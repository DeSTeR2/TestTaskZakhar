using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsAnimation : MonoBehaviour
{
    [SerializeField] SingleCoin _coinToCreate;
    [SerializeField, Range(5,200)] int _coinNumber;
    [SerializeField] float _timeToCreateNextCoin;

    [Header("Sprites")]
    [SerializeField] List<Sprite> _sprites;

    [Header("Spawn")]
    [SerializeField] Transform _spawnPoint;

    private float _spawnOffset;
    private int _coinSpawned;

    List<SingleCoin> _coinPull = new List<SingleCoin>();



    private void OnEnable() {
        _spawnOffset = Mathf.Max(Screen.width - Screen.width*0.1f, 1920-1920*0.1f);
        _coinSpawned = 0;
        StartCoroutine(SpawnCoins());
    }

    private IEnumerator SpawnCoins() {
        Vector3 position = _spawnPoint.position;
        position.x += Random.Range(-_spawnOffset, _spawnOffset);

        Sprite coinSprite = _sprites[(int)Random.Range(0, _sprites.Count)];

        if (_coinPull.Count <= _coinSpawned) {
            SingleCoin coin = Instantiate(_coinToCreate, position, Quaternion.identity, _spawnPoint);
            _coinPull.Add(coin);
        } else {
            _coinPull[_coinSpawned].gameObject.transform.position = position;
        }
        _coinPull[_coinSpawned].gameObject.SetActive(true);
        _coinPull[_coinSpawned].Init(coinSprite);

        _coinSpawned++;

        if (_coinSpawned < _coinNumber) {
            yield return new WaitForSeconds(_timeToCreateNextCoin);
            StartCoroutine(SpawnCoins());
        }
    }

    private void OnDisable() {
        for (int i=0; i< _coinPull.Count; i++) {
            _coinPull[i].gameObject.SetActive(false);
        }
    }
}
