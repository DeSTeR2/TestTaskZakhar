using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _addMoney;

    private void Awake() {
        MoneyManager.onLevelUpAddMoney += Init;
        gameObject.SetActive(false);
    }

    private void Subscribe(int level) {
        gameObject.SetActive(true);
    }

    private void Init(float money) {
        _addMoney.text = $"+{money}$";
        SoundManager.instance.NewLevel();
    }

    private void OnDestroy() {
        MoneyManager.onLevelUpAddMoney -= Init;
    }
}
