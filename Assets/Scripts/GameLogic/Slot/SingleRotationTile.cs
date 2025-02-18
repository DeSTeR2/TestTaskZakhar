using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleRotationTile : MonoBehaviour
{
    Image _image;
    public SingleTile _tileInfo;

    public void SetUp() {
        _image = GetComponent<Image>();   
        RectTransform rt = GetComponent<RectTransform>();
        rt.anchorMin = Vector3.zero;
        rt.anchorMax = Vector3.one;
        rt.sizeDelta = Vector2.zero;

    }

    public void NewTileInfo(SingleTile info) {
        _tileInfo = info;
        _image.sprite = _tileInfo.GetSprite();
    }

    public float GetPrice(int col) {
        return _tileInfo.GetPrice(col);
    }

    public static bool CompareTiles(SingleRotationTile tile1, SingleRotationTile tile2) {
        //Debug.Log(tile1._tileInfo.GetSprite().name + " " + tile2._tileInfo.GetSprite().name);
        return tile1._tileInfo.GetSprite() == tile2._tileInfo.GetSprite();
    }
}
