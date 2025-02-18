using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDelegate : MonoBehaviour {

    [Header("Buttons")]
    [SerializeField] Button _spin;
    [SerializeField] Button _autoSpin;
    [SerializeField] Button _settings;

    [Header("Objects")]
    [SerializeField] Board _board;
    [SerializeField] GameObject _systemSettings;
    [SerializeField] MoneyManager _moneyManager;
        
    private void Start() {
        Subscribe();
    }


    private void Subscribe() {
        Board.onBoardRotated += OnBoardRotate;

        _spin.onClick.AddListener(delegate {
            if (_moneyManager.CanSpin() == false || _board.IsSpining) return;
            _board.Spin();

            SoundManager.instance.ButtonClick();
            _spin.interactable = false;
        });

        _autoSpin.onClick.AddListener(delegate {
            if (_board.IsSpining)
            {
                _board.Stop();
                return;
            }

            if (_moneyManager.CanSpin() == false) return;
            _board.AutoSpin();

            SoundManager.instance.ButtonClick();
            _spin.interactable = false;
        });

        _settings.onClick.AddListener(delegate {
            if (_board.IsSpining == false)
            {
                _systemSettings.SetActive(true);
            }
        });
    }

    private void OnDestroy() {
        UnSubscribe();
    }

    private void UnSubscribe() {
        Board.onBoardRotated -= OnBoardRotate;
    }

    public void OnBoardRotate() {
        _spin.interactable = true;
        _autoSpin.interactable = true;
    }
}
