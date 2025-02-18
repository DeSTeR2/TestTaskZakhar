using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SystemSettings : MonoBehaviour
{
    [SerializeField] Transform itemParent;

    List<SettingsItem> items = new();

    private void OnEnable()
    {
        if (MoneyManager.instance == null) return;
        float bet = MoneyManager.instance.GetBet();
        foreach (var btn in items)
        {
            btn.SetActive(bet);
        }
    }

    private void Start()
    {
        int[] bets = MoneyManager.instance.GetBets();
        for (int i=0; i<bets.Length;i++)
        {
            SettingsItem item = itemParent.GetChild(i).GetComponent<SettingsItem>();
            items.Add(item);
            item.SetText(bets[i]);
        }

        OnEnable();
    }
}
