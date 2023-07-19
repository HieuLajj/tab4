using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Arrow : MonoBehaviour
{
    public GiftUIManager giftUIManager;
    public TextMeshProUGUI textX;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RewardNo"))
        {
            //var multipier = other.gameObject.name;
            int numberReward = other.gameObject.GetComponent<TextRewardItem>().number;
           
            Controller.Instance.AmountCoin = UIManager.Instance.giftUIManager.RandomReward;
            Controller.Instance.AmountCoinX2 = numberReward* UIManager.Instance.giftUIManager.RandomReward;
            giftUIManager.RewardTMP.text = "Get X" + numberReward;
            textX.text = $"+{Controller.Instance.AmountCoinX2}";
        }
        else
        {
           // Debug.Log(other.gameObject.name);
        }
    }

}