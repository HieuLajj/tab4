using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardManager : MonoBehaviour
{
    [SerializeField] private GameObject pileOfCoins;
    [SerializeField] private TextMeshProUGUI counter;
    [SerializeField] private Vector2[] initialPos;
    [SerializeField] private Quaternion[] initialRotation;
    [SerializeField] private int coinsAmount;
    [SerializeField] private Image coinimage;

    void Start()
    {

        if (coinsAmount == 0)
            coinsAmount = 10; // you need to change this value based on the number of coins in the inspector

        initialPos = new Vector2[coinsAmount];
        initialRotation = new Quaternion[coinsAmount];

        for (int i = 0; i < pileOfCoins.transform.childCount; i++)
        {
            initialPos[i] = pileOfCoins.transform.GetChild(i).position;
            initialRotation[i] = pileOfCoins.transform.GetChild(i).rotation;
        }
    }

    private void Reset(Vector2 position)
    {
        for (int i = 0; i < pileOfCoins.transform.childCount; i++)
        {
            //pileOfCoins.transform.GetChild(i).position = initialPos[i];
            //pileOfCoins.transform.GetChild(i).position = position;
            pileOfCoins.transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition= position + new Vector2(Random.Range(-45,45), Random.Range(-45,45));;
            pileOfCoins.transform.GetChild(i).rotation = initialRotation[i];
        }
    }

    public void CountCoins(Vector2 position)
    {
      
        Reset(position);
        
        pileOfCoins.SetActive(true);
        var delay = 0f;

        for (int i = 0; i < pileOfCoins.transform.childCount; i++)
        {
            pileOfCoins.transform.GetChild(i).DOScale(1f, 0.3f).SetDelay(delay).SetEase(Ease.OutBack);


            //bien doi image sang vi tri canvas tong

            Vector2 imagePosition = Vector2.zero;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(UIManager.Instance.canvasRectTransform, coinimage.transform.position, null, out imagePosition);

            pileOfCoins.transform.GetChild(i).GetComponent<RectTransform>().DOAnchorPos(imagePosition, 0.8f)
                .SetDelay(delay + 0.5f).SetEase(Ease.InBack).OnComplete(() => {
                    //Debug.Log("+10");
                });


            pileOfCoins.transform.GetChild(i).DORotate(Vector3.zero, 0.5f).SetDelay(delay + 0.5f)
                .SetEase(Ease.Flash);


            pileOfCoins.transform.GetChild(i).DOScale(0f, 0.3f).SetDelay(delay + 1.5f).SetEase(Ease.OutBack);

            delay += 0.1f;

            counter.transform.parent.GetChild(0).transform.DOScale(1.1f, 0.1f).SetLoops(10, LoopType.Yoyo).SetEase(Ease.InOutSine).SetDelay(1.2f);
        }

        StartCoroutine(CountDollars());
    }


    IEnumerator CountDollars()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        Controller.Instance.CoinPlayer += PlayerPrefs.GetInt("BPrize");
        //Debug.Log(Controller.Instance.CoinPlayer+"fee"+PlayerPrefs.GetInt("BPrize"));
        // PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + PlayerPrefs.GetInt("BPrize"));
        // counter.text = Utiliti.SetCoinsText(PlayerPrefs.GetInt("Coin"));
        PlayerPrefs.SetInt("BPrize", 0);
    }
}
