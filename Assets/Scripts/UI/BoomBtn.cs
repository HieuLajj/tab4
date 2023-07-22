using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class BoomBtn : MonoBehaviour
{
    public float countdownTime = 10f;
    public bool isCountdownActive = false;
    private Button buttonBoom;
    public Image BackgroundImage;
    public Image BoomImage;

    public GameObject Money;
    public GameObject Video;
    public GameObject Waring;
    private void Awake()
    {
        buttonBoom = transform.GetComponent<Button>();
        BoomImage = transform.GetComponent<Image>();
    }
    public void ActiveBoom()
    {
        if (!isCountdownActive)
        {
            Controller.Instance.Boom.SetActive(true); 
            Waring.gameObject.SetActive(false);     
            StartCoroutine(StartCountdown());
        }
    }

    private IEnumerator StartCountdown()
    {
        buttonBoom.interactable = false;
        isCountdownActive = true;
        float currentTime = countdownTime;

        while (currentTime > 0)
        {
            
            yield return new WaitForSeconds(1f);
            currentTime--;
         //   BackgroundImage.fillAmount = currentTime / countdownTime;
            BackgroundImage.DOFillAmount(currentTime / countdownTime, 1f);
        }

       
        isCountdownActive = false;
        buttonBoom.interactable = true;
        Waring.gameObject.SetActive(true);  
        UpdateView();
    }

    public void AnUIBoom(){
        BackgroundImage.enabled = false;
        BoomImage.enabled = false;
        if (buttonBoom == null) return;
        buttonBoom.interactable = false;
    }

    public void HienUIBoom(){
        BackgroundImage.enabled = true;
        BoomImage.enabled = true;
        if(!isCountdownActive){
            buttonBoom.interactable = true;
            UpdateView();
            Waring.gameObject.SetActive(true);  
        }
    }

    public void UpdateView(){
        if(Controller.Instance.CoinPlayer >= 100){
            Money.gameObject.SetActive(true);
            Video.gameObject.SetActive(false);
        }else{
            Money.gameObject.SetActive(false);
            Video.gameObject.SetActive(true);
        }
    }
}
