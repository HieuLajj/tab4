using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoSizeUI : MonoBehaviour
{
    private void Awake()
    {
        SetScale();
    }

    private void SetScale()
    {

        CanvasScaler canvasScaler = GetComponent<CanvasScaler>();
        Vector2 scrSize = GetComponent<RectTransform>().sizeDelta;

        if (scrSize.y/ scrSize.x  <= 1.4)
        {
            canvasScaler.matchWidthOrHeight = 1f;
        }
        else
        {
            canvasScaler.matchWidthOrHeight = 0f;
        }
    }
}