using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropDownMenu : MonoBehaviour
{
    [SerializeField] List<Button> _buttons;

    [Header("Targets")]
    [SerializeField] Transform _defaultPostion;
    [SerializeField] List<Transform> _targets;

    [Header("Animation settings")]
    [SerializeField] float _openDuration;
    [SerializeField] Ease _openEase;
    [Space]
    [SerializeField] float _closeDuration;
    [SerializeField] Ease _closeEase;

    private enum MenuStatus {
        Close,
        Open
    }

    private MenuStatus _menuStatus;

    public void DropDown() {
        switch (_menuStatus) {
            case MenuStatus.Close:
                StartCoroutine(Open());
                _menuStatus = MenuStatus.Open;
                break;
            case MenuStatus.Open:
                StartCoroutine(Close());
                _menuStatus = MenuStatus.Close;
                break;
        }
    }

    private IEnumerator Open() {
        for (int i=0; i<_buttons.Count; i++) {
            _buttons[i].gameObject.SetActive(true);
            _buttons[i].transform.DOLocalMove(_targets[i].localPosition, _openDuration).SetEase(_openEase);
        }

        yield return new WaitForSeconds(_closeDuration);

        for (int i = 0; i < _buttons.Count; i++) {
            _buttons[i].interactable = true;
        }
    }

    private IEnumerator Close() {
        for (int i = 0; i < _buttons.Count; i++) {
            _buttons[i].interactable = false;
            _buttons[i].transform.DOLocalMove(_defaultPostion.localPosition, _closeDuration).SetEase(_closeEase);
        }

        yield return new WaitForSeconds(_closeDuration);

        for (int i = 0; i < _buttons.Count; i++) {
            _buttons[i].gameObject.SetActive(false);
        }
    }
}
