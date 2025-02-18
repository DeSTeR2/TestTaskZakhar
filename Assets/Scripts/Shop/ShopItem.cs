using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour {
    [Header("Items")]
    [SerializeField] Image _itemImage;
    [SerializeField] Image _bgImage;
    [SerializeField] Button _bgButton;
    [SerializeField] Button _panelButton;
    [SerializeField] TextMeshProUGUI _priceText;

    [Header("Settings")]
    [SerializeField] public Image _owned;
    [SerializeField] public Image _unOwned;

    [Header("Settings")]
    [SerializeField] ShopItemScriptable _info;

    [Space]
    [SerializeField] string _coinNumberSave;

    private void Start() {
        if (_info._itemImage != null) {
            _itemImage.sprite = _info._itemImage;
        }

        CheckStatus();
        _priceText.text = _info._price.ToString();

        _bgButton.onClick.AddListener(delegate { Choose(); });
        _panelButton.onClick.AddListener(delegate { Buy(); });
    }

    private void CheckStatus() {
        switch (_info._status) {
            case ShopItemStatus.Unowned:
                _bgImage.sprite = _owned.sprite;
                _bgImage.color = _owned.color;
                break;

            case ShopItemStatus.Owned:
                _bgImage.sprite = _unOwned.sprite;
                _bgImage.color = _unOwned.color;
                break;
        }
    }

    public void Choose() {
        if (_info._status == ShopItemStatus.Unowned) return;
        ShopManager.instance.SetImage(_info._type, _info._itemImage);
    }

    private void Buy() {
        int balance = ShopManager.instance.Balance();
        if (balance >= _info._price && _info._status == ShopItemStatus.Unowned) {
            _info._status = ShopItemStatus.Owned;
            CheckStatus();
            Choose();

            ShopManager.instance.Buy(_info._price);
            ShopManager.instance.SetImage(_info._type, _info._itemImage);

        }
    }
}
