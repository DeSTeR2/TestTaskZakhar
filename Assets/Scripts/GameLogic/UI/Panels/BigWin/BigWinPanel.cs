using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BigWinPanel : MonoBehaviour
{
    [SerializeField] float _panelLifeTime;
    [SerializeField] TextMeshProUGUI text;

    public void OpenPanel(float win)
    {
        gameObject.SetActive(true);
        text.text = win.ToString("0.00") + "$";

        StartCoroutine(Disable());

        SoundManager.instance.BigWin();

        IEnumerator Disable()
        {

            yield return new WaitForSeconds(_panelLifeTime);
            gameObject.SetActive(false);
        }
    }
}
