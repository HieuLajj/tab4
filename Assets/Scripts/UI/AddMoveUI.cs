using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMoveUI : UIFuctionUltiliti
{
    public void AddTenMove(){
        LevelManager.Instance.LimitMoveInt += 10;
        gameObject.SetActive(false);
    }
    public void ResetLevel(){
        LevelManager.Instance.LoadLevelInGame(PlayerPrefs.GetInt("Playinglevel"));
        gameObject.SetActive(false);
    }
}
