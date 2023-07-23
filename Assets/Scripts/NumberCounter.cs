using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class NumberCounter : MonoBehaviour
{

    public float scaleDuration = 0.1f;
    public float targetScale = 1.2f;
    private Vector3 originalScale;
    public TextMeshProUGUI Text;
    public int CountFPS = 30;
    public float Duration = 1f;
    public string NumberFormat = "N0";
    private int _value;
    public int Value
    {
        get
        {
            return _value;
        }
        set
        {
            if(Mathf.Abs(value-_value)>3){
                _value = 0;
            }
            UpdateText(value);
            _value = value;
        }
    }
    private Coroutine CountingCoroutine;

    private void Awake()
    {
        Text = GetComponent<TextMeshProUGUI>();
        originalScale = transform.localScale;
       
       
    }

    private void UpdateText(int newValue)
    {
        if (CountingCoroutine != null)
        {
            StopCoroutine(CountingCoroutine);
        }

        CountingCoroutine = StartCoroutine(CountText(newValue));
    }

    private IEnumerator CountText(int newValue)
    {
        WaitForSeconds Wait = new WaitForSeconds(1f / CountFPS);
        int previousValue = _value;
        int stepAmount;

        if (newValue - previousValue < 0)
        {
            stepAmount = Mathf.FloorToInt((newValue - previousValue) / (CountFPS * Duration)); // newValue = -20, previousValue = 0. CountFPS = 30, and Duration = 1; (-20- 0) / (30*1) // -0.66667 (ceiltoint)-> 0
        }
        else
        {
            stepAmount = Mathf.CeilToInt((newValue - previousValue) / (CountFPS * Duration)); // newValue = 20, previousValue = 0. CountFPS = 30, and Duration = 1; (20- 0) / (30*1) // 0.66667 (floortoint)-> 0
        }

        if (previousValue < newValue)
        {
            while(previousValue < newValue)
            {
                previousValue += stepAmount;
                if (previousValue > newValue)
                {
                    previousValue = newValue;
                }

                Text.SetText($"{previousValue.ToString(NumberFormat)} Moves");
                ScaleText();
                yield return Wait;
            }
        }
        else
        {
            while (previousValue > newValue)
            {
                previousValue += stepAmount; // (-20 - 0) / (30 * 1) = -0.66667 -> -1              0 + -1 = -1
                if (previousValue < newValue)
                {
                    previousValue = newValue;
                }

                ScaleText();
                Text.SetText($"{previousValue.ToString(NumberFormat)} Moves");
               
                //Text.SetText(previousValue.ToString(NumberFormat));

                yield return Wait;
            }
        }
    }

    private void ScaleText()
    {
        transform.DOScale(targetScale, scaleDuration).OnComplete(ResetScale);
    }

    private void ResetScale()
    {
        transform.DOScale(originalScale, scaleDuration);
    }
}
