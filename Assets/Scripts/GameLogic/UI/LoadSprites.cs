using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadSprites : MonoBehaviour
{
    [SerializeField] ShopItemType _type;
    [SerializeField] Image _image;
    [SerializeField] ShopScriptable _shop;

    private void Start() {
        _image = GetComponent<Image>();
        _image.sprite = _shop.GetSprite(_type);
    }
}

