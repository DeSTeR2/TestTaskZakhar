using DG.Tweening;
using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _balanceText;
    [SerializeField] TextMeshProUGUI _totalBetText;
    [SerializeField] TextMeshProUGUI _winText;
    [SerializeField] TextMeshProUGUI _winTextFly;

    [Space]
    [SerializeField] int[] _betAmounds;

    [Space]
    [SerializeField] string _saveBalance;

    [Header("Win animations")]
    [Header("Win text fly animation")]
    [SerializeField] float _winTextFlyDuration;
    [SerializeField] Ease _winTextFlyEase;
    [SerializeField] Transform _winTextTarget;

    [Header("Big Win animation")]
    [SerializeField] BigWinPanel _bigWinPanel;
    [SerializeField] float _winBetMultyToTrigetBigWin;

    float _money;
    int _betIndex = 0;
    float _win = 0;

    public static float bet;
    public static float moneyForNewLevel;

    public static Action<float> onLevelUpAddMoney;

    public static MoneyManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _money = PlayerPrefs.GetFloat(_saveBalance, 100);
        _betIndex = 0;

        bet = _betAmounds[0];

        ConnectionManager.onLineWin += Win;
        ConnectionManager.onConnectionChecked += AnimateWin;
        NewBalanceAnimation.onNewBalanceEndAnimation += AddLevelUpMoney;

        UpdateUI();
    }

    private void UpdateUI()
    {
        _balanceText.text = _money.ToString("0.00") + "$";
        _totalBetText.text = bet.ToString("0.00") + "$";
        _winText.text = $"{_win.ToString("0.00")}$";

        PlayerPrefs.SetFloat(_saveBalance, _money);
    }

    public void SetBet(float price)
    {
        bet = price;
        UpdateUI();
    }

    public float GetBet() => bet;

    public void Bet()
    {
        _money -= bet;

        UpdateUI();
        _win = 0;
    }

    public bool CanSpin()
    {
        if (_money < bet) return false;
        return true;
    }

    public void Win(int coll, SingleRotationTile tile)
    {
        _win += tile.GetPrice(coll) * bet;
    }

    public void AnimateWin()
    {
        _winText.text = _win.ToString("0.00") + "$";
        _winTextFly.text = _win.ToString("0.00") + "$";
        _winTextFly.transform.position = _winText.transform.position;

        if (_win != 0)
        {
            StartCoroutine(WinTextFly());
        }

        if (_win >= _winBetMultyToTrigetBigWin * bet)
        {
            _bigWinPanel.OpenPanel(_win);
        }

        IEnumerator WinTextFly()
        {
            UpdateUI();
            yield return null;
            yield return null;

            _winTextFly.gameObject.SetActive(true);
            _winTextFly.transform.DOMove(_winTextTarget.transform.position, _winTextFlyDuration).SetEase(_winTextFlyEase);

            yield return new WaitForSeconds(_winTextFlyDuration);
            _winTextFly.gameObject.SetActive(false);

            _money += _win;
            UpdateUI();
        }
    }

    private void AddLevelUpMoney(float duration)
    {
        StartCoroutine(Anim());

        IEnumerator Anim()
        {
            _money += moneyForNewLevel;
            yield return new WaitForSeconds(duration);
            UpdateUI();
        }

    }

    public int[] GetBets() => _betAmounds;

    private void OnDestroy()
    {
        ConnectionManager.onLineWin -= Win;
        ConnectionManager.onConnectionChecked -= AnimateWin;
        NewBalanceAnimation.onNewBalanceEndAnimation -= AddLevelUpMoney;
    }
}
