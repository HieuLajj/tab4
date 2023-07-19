using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyUI : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable() {
         UIManager.Instance.GameUIIngame.CoinsUI.SetActive(true);
    }

    private void OnDisable() {
         UIManager.Instance.GameUIIngame.CoinsUI?.SetActive(false);
    }
}
