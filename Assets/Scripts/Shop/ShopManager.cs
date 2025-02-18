using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

    [Header("Shop Image")]
    [SerializeField] Image _shopCanonImage;
    [SerializeField] Image _shopBallImage;
    [SerializeField] Image _shopPlatformImage;

    [SerializeField] ShopScriptable _shopScriptable;
    [SerializeField] Balance _balance;
    Dictionary<ShopItemType, Sprite> _sprites;

    public static ShopManager instance;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        _sprites = new Dictionary<ShopItemType, Sprite>();

        int shopItemCount = Enum.GetNames(typeof(ShopItemType)).Length;
        _shopScriptable.CreateAsset();
        for (int i = 0; i < shopItemCount; i++) {
            ShopItemType type = (ShopItemType)i;
            _sprites.Add(type, _shopScriptable.GetSprite(type));
        }
        UpdateImage();
    }

    public void UpdateImage() {
        int shopItemCount = Enum.GetNames(typeof(ShopItemType)).Length;
        for (int i = 0; i < shopItemCount; i++) {
            ShopItemType type = (ShopItemType)i;
            switch (type) {
                case ShopItemType.Canon:
                    _shopCanonImage.sprite = _sprites[type];
                    break;
                case ShopItemType.Ball:
                    _shopBallImage.sprite = _sprites[type];
                    break;
                case ShopItemType.Platform:
                    _shopPlatformImage.sprite = _sprites[type];
                    break;
            }
        }
    }

    public int Balance() {
        return _balance.GetBalance();
    }

    public void Buy(int price) {
        _balance.DecriceBalance(price);
    }

    public void SetImage(ShopItemType _type, Sprite sprite) {
        _shopScriptable.ChangeSprite(_type, sprite);

        if (_sprites[_type] != null)
            _sprites[_type] = _shopScriptable.GetSprite(_type);
        
        UpdateImage();
    }
}
