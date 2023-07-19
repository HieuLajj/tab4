using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.U2D;
using UnityEngine.UIElements;

public class GiftUIManager : UIFuctionUltiliti
{
    // Start is called before the first frame update
    public TextMeshProUGUI RewardTMP;
    public Animator animatorArrow;
    public int RandomReward = 0;
    public TextMeshProUGUI TextMeshNotads;
    private void OnEnable()
    {
        UIManager.Instance.GameUIIngame.CoinsUI.SetActive(true);
        if (!animatorArrow.isActiveAndEnabled)
        {
            animatorArrow.enabled = true;
        }
        RandomReward = Random.Range(10,30);
        SetUpTextMeshNoAds(RandomReward);
        UIManager.Instance.DisplayGamePlay();
    }
    public void CollectX2()
    {
        animatorArrow.enabled = false;
        UIManager.Instance.GameUIIngame.OpenGift();
        PlayerPrefs.SetInt("BPrize", Controller.Instance.AmountCoinX2);
        //manager.CountCoins();
    }

    public void CollectNotX2()
    {
        PlayerPrefs.SetInt("BPrize", Controller.Instance.AmountCoin);
        animatorArrow.enabled = false;
        UIManager.Instance.GameUIIngame.OpenGift();
        //manager.CountCoins();
    }

    private void OnDisable()
    {
        if (UIManager.Instance.UIBoom == null) return;
        UIManager.Instance.UIBoom.SetActive(true);
        UIManager.Instance.GameUIIngame.CoinsUI.SetActive(false);
    }

    public void SetUpTextMeshNoAds(float a)
    {
        TextMeshNotads.text = $"<u> Get {a}</u>";
        // <sprite name=\"coin\">
    }
}
