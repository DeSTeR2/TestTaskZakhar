using UnityEngine;

[CreateAssetMenu(fileName = "ShopItem", menuName = "Shop/ShopItem", order = 1)]
public class ShopItemScriptable : ScriptableObject
{
    [Header("Settings")]
    [SerializeField] public Sprite _itemImage;
    [SerializeField] public ShopItemStatus _status;
    [SerializeField] public ShopItemType _type;
    [SerializeField] public int _price;
}
