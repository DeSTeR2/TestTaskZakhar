using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

[CreateAssetMenu(fileName = "Tiles", menuName = "Sloth/Tiles", order = 0)]
public class Tiles : ScriptableObject
{
    [SerializeField] List<SingleTile> _tiles;

    float maxProb = 0;

    public SingleTile GetSingleTile() {
        if (maxProb == 0)
        {
            foreach (var tile in _tiles)
            {
                maxProb += tile.probability;
            }
        }
        
        SingleTile ans = new SingleTile();
        float rng = Random.Range(0f, maxProb);
        float sumRng = 0;

        for (int i=0; i < _tiles.Count; i++) {
            if (sumRng <= rng && rng <= sumRng + _tiles[i].probability) {
                ans = _tiles[i];
                break;
            }

            sumRng += _tiles[i].probability;
        }
        
        return ans;
    }

    public List<SingleTile> GetTiles() {
        return _tiles;
    }
}
