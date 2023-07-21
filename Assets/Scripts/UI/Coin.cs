using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Coin : MonoBehaviour
{
    public TextMeshProUGUI textCoin;
    private void OnEnable()
    {
        if (UIManager.Instance.DailyCanvas.activeInHierarchy || UIManager.Instance.CompleteLevelUI.activeInHierarchy)
        {
            textCoin.color = Color.black;
        }
        else
        {
            textCoin.color = Color.white;
        }
    }
}
