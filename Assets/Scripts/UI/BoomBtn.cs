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
        }
    }
}
