using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeUI : MonoBehaviour
{
    private void OnEnable() {
        if(Controller.Instance.gameState == StateGame.PLAY){
            Controller.Instance.gameState = StateGame.AWAIT;
        }
    }
    public void StartGame(){
        LevelManager.Instance.StartGame();
        gameObject.SetActive(false);
    }

    public void LevelActive(){
        UIManager.Instance.SelectLevelUI.SetActive(true);
    }

    public void ShopActive(){
        UIManager.Instance.SelectShopUI.SetActive(true);
    }

    public void SettingActive()
    {
        UIManager.Instance.SelectSettingUI.SetActive(true);
    }
}
