using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIFuctionUltiliti : MonoBehaviour
{
    private void OnEnable() {
        Controller.Instance.gameState = StateGame.AWAIT;
        if (!UIManager.Instance.UIBoom.activeInHierarchy) return;
        UIManager.Instance.UIBoom?.GetComponent<BoomBtn>().AnUIBoom();

    }
    private void OnDisable() {
        //if (Controller.Instance==null || Controller.Instance.Equals(null))
        //{
        //    return;
        //}
       
        if (Controller.Instance.gameState == StateGame.AWAITLOAD || UIManager.Instance.SelectHomeUI.activeInHierarchy || Controller.Instance.gameState == StateGame.AWAITNEW) return;
        
        Controller.Instance.gameState = StateGame.PLAY;
        if (UIManager.Instance.UIBoom.activeInHierarchy ) return;
        UIManager.Instance.UIBoom?.GetComponent<BoomBtn>().HienUIBoom();
      
    }
}
