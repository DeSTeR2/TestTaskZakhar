using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsItem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI priceText;

    float price = -1;
    Button btn;

    public void SetText(float price) {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SetPrice);

        this.price = price;
        priceText.text = price.ToString("0.00") + "$";
    }

    public void SetActive(float price)
    {
        if (this.price == price)
        {
            btn.Select();
        }
    }

    private void SetPrice()
    {
        MoneyManager.instance.SetBet(price);
    }
}
