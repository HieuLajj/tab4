using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : UIFuctionUltiliti
{
    public GameObject BtnContinue;
    public void NextLevelWhenBtn()
    {
        gameObject.SetActive(false);
        Controller.Instance.gameState = StateGame.AWAIT;
        if(UIManager.Instance.SelectHomeUI.activeInHierarchy){

        }else if(UIManager.Instance.CheckAtivePanel()){
            Controller.Instance.gameState = StateGame.AWAITNEW;
        }
        else{
            LevelManager.Instance.NextLevel();
        }
        
    }
    private void OnEnable()
    {
        UIManager.Instance.GameUIIngame.CoinsUI.SetActive(true);
        MusicController.Instance.PlayClip(MusicController.Instance.CompleteClip);
    }

    private void OnDisable()
    {
        BtnContinue.SetActive(false);  
        UIManager.Instance.GameUIIngame.CoinsUI.SetActive(false);
    }

    public void DisplayButtonCotinue()
    {
        Invoke("ActiveBtC", 3);
    }
   

    public void ActiveBtC()
    {
        BtnContinue?.SetActive(true);
    }
    public void SettingActive()
    {
        Controller.Instance.gameState = StateGame.AWAITNEW;
        UIManager.Instance.SelectSettingUI.SetActive(true);
        gameObject.SetActive(false);
    }
}
