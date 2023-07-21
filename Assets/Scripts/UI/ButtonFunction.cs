using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunction : MonoBehaviour
{
    // Start is called before the first frame update
   public void ClickFuction()
   {
        if(gameObject.name == "LevelFT")
        {
            ActiveLevelUI();
        }else if(gameObject.name == "ShopFT")
        {
            ActiveShopUI();
        }else if(gameObject.name == "BackFT"){
            BackHomeUI();
        }else if(gameObject.name == "ResetFT"){
            if (Controller.Instance.gameState == StateGame.AWAITLOAD) return;
            ActiveResetUI();
        }
        
       
   }
    private void ActiveLevelUI()
    {
        if (UIManager.Instance.SelectLevelUI.activeInHierarchy)
        {
            UIManager.Instance.SelectLevelUI.SetActive(false);
        }
        else
        {
            UIManager.Instance.SelectLevelUI.SetActive(true);
        }
    }
    // private void DisableOject()
    // {
    //     transform.parent.gameObject.SetActive(false);
    // }

    private void ActiveShopUI()
    {
        if (UIManager.Instance.SelectShopUI.activeInHierarchy)
        {
            UIManager.Instance.SelectShopUI.SetActive(false);
        }
        else
        {
            UIManager.Instance.SelectShopUI.SetActive(true);
        }
    }

    private void BackHomeUI(){
        UIManager.Instance.SelectHomeUI.SetActive(true);       
    }

    public void ActiveResetUI(){
        LevelManager.Instance.LoadLevelInGame(PlayerPrefs.GetInt("Playinglevel"));
    }
}
