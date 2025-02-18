using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Single Tile", menuName = "Sloth/SingleTile", order = 1)]
public class SingleTile : ScriptableObject
{
    [SerializeField] Sprite _sprite;
    [SerializeField] public float probability;
    [SerializeField] public float[] prices;
    public Sprite GetSprite() {
        return _sprite;
    }

    public float GetPrice(int col) {
        return prices[col-1];
    }
}
