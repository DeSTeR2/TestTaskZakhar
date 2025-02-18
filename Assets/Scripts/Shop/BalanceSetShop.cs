using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BalanceSetShop : MonoBehaviour {
    [SerializeField] Balance _balance;
    [SerializeField] TextMeshProUGUI _balanceText;

    public static BalanceSetShop instance;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        _balance.onBalanceChange += CheckText;
        _balanceText.text = _balance.GetBalance().ToString();
    }

    public void CheckText(int balance) {
        _balanceText.text = balance.ToString();
    }

    public void Reward() {
        _balance.Reward();
    }
}