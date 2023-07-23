using UnityEngine;
using DG.Tweening;

public class Scale : MonoBehaviour
{
    #region Variables

    private Vector3 _originalScale;
    private Vector3 _scaleTo;

    #endregion
    
    
    void Start()
    {
        _originalScale = transform.localScale;
        _scaleTo = _originalScale * 1.08f;

        OnScale();
    }

    private void OnScale()
    {
        transform.DOScale(_scaleTo, 2.0f)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }
}