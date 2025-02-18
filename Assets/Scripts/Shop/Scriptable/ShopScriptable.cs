using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Shop", menuName = "Shop/Shop", order = 0)]
public class ShopScriptable : ScriptableObject
{
    public List<GameSkin> skinList;
    public Sprite _defauilImage;
    
    private Dictionary<ShopItemType, Sprite> sprites = null;

    public void CreateAsset() {
        if (sprites == null) {
            sprites = new Dictionary<ShopItemType, Sprite>();

            GameSkin[] arr = skinList.ToArray();
            Array.Sort(arr, new GameSkin.Comparer());
            skinList = new List<GameSkin>(arr);

            for (int i = 0; i < skinList.Count; i++) {
                sprites.Add(skinList[i]._type, skinList[i]._sprite);
            }
        }
    }

    public void ChangeSprite(ShopItemType type, Sprite sprite) {
        sprites[type] = sprite;
        skinList[(int)type]._sprite = sprite;
    }

    public Sprite GetSprite(ShopItemType type) {
        return sprites[type];
    }
}
