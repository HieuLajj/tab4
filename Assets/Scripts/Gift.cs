using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour
{
    public Transform TargetPosition;
    public void ResetGift()
    {        
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(TargetPosition.position);
        Vector2 canvasPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(UIManager.Instance.canvasRectTransform, screenPosition, Camera.main, out canvasPosition);
        
        UIManager.Instance.RewardManager.CountCoins(canvasPosition);
        StartCoroutine(AwaitClear());
    }
    IEnumerator AwaitClear()
    {
        yield return new WaitForSeconds(3f);
        UIManager.Instance.GameUIIngame.ClearGift();
    }
}
