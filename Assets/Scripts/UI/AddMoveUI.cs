using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMoveUI : MonoBehaviour
{
    public void AddTenMove(){
        LevelManager.Instance.LimitMoveInt += 10;
        gameObject.SetActive(false);
    }
    public void ResetLevel(){
        LevelManager.Instance.LoadLevelInGame(PlayerPrefs.GetInt("Playinglevel"));
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        Controller.Instance.gameState = StateGame.AWAIT;
        MusicController.Instance.PlayClip(MusicController.Instance.LoseClip);
    }

    private void OnDisable()
    {
        if (Controller.Instance.gameState == StateGame.AWAITLOAD) return;
        Controller.Instance.gameState = StateGame.PLAY;
    }
}
