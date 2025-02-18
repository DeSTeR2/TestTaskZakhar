using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSkin", menuName = "GameSkin", order = 0)]
public class GameSkin : ScriptableObject
{
    [SerializeField] public Sprite _sprite;
    [SerializeField] public ShopItemType _type;

    public Sprite GetSprite() {
        return _sprite;
    }

    public void SetSprite(Sprite sprite) {
        _sprite = sprite;
    }

    public class Comparer: IComparer {
        int IComparer.Compare(object a, object b) {
            GameSkin c1 = (GameSkin)a;
            GameSkin c2 = (GameSkin)b;

            if ((int)c1._type > (int)c2._type)
                return 1;

            if ((int)c1._type < (int)c2._type)
                return -1;

            else
                return 0;
        }
    }
}
