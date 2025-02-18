using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


[CreateAssetMenu(fileName = "Balance", menuName = "Balance")]
public class Balance : ScriptableObject
{
    [SerializeField] int balance;
    [SerializeField] int minCoin;
    [SerializeField] int maxCoin;

    bool rewarded = false;
    public Action<int> onBalanceChange;

    public void DecriceBalance(int amound) {
        balance -= amound;
        onBalanceChange?.Invoke(balance);
    }

    public void AddBalance(int amound) {
        balance += amound;
        onBalanceChange?.Invoke(balance);
    }

    public int GetBalance() {
        return balance;
    }

    public void Reward() {
        int toAdd = Random.Range(minCoin, maxCoin);
        AddBalance(toAdd);
    }
}
