using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class SwitchToggle : MonoBehaviour
{
    [SerializeField] RectTransform uiHandleRectTransform;
    public Sprite[] spriteImage;

    Image backgroundImage, handleImage;

    //Color backgroundDefaultColor, handleDefaultColor;

    public Toggle toggle;
    public Image DesCripImage;

    //public string name;
    Vector2 handlePosition;

    public SettingT settingT = SettingT.SOUND;
    void Awake()
    {
        toggle = GetComponent<Toggle>();

        handlePosition = uiHandleRectTransform.anchoredPosition;

        backgroundImage = uiHandleRectTransform.parent.GetComponent<Image>();
        handleImage = uiHandleRectTransform.GetComponent<Image>();

        //backgroundDefaultColor = backgroundImage.color;
        //handleDefaultColor = handleImage.color;

        toggle.onValueChanged.AddListener(OnSwitch);

        if (toggle.isOn)
            OnSwitch(true);
    }

    void OnSwitch(bool on)
    {
        //uiHandleRectTransform.anchoredPosition = on ? handlePosition * -1 : handlePosition ; // no anim
        uiHandleRectTransform.DOAnchorPos(on ? handlePosition * -1 : handlePosition, .4f).SetEase(Ease.InOutBack);
        if (on)
        {
            handleImage.sprite = spriteImage[0];
            DesCripImage.sprite = spriteImage[2];
        }
        else
        {
            handleImage.sprite = spriteImage[1];
            DesCripImage.sprite = spriteImage[3];
        }

        ChangeSoundorVibrator(on);
        
        //backgroundImage.color = on ? backgroundActiveColor : backgroundDefaultColor ; // no anim
        //backgroundImage.DOColor(on ? backgroundActiveColor : backgroundDefaultColor, .6f);

        //handleImage.color = on ? handleActiveColor : handleDefaultColor ; // no anim
        //handleImage.DOColor(on ? handleActiveColor : handleDefaultColor, .4f);
    }

    void OnDestroy()
    {
        toggle.onValueChanged.RemoveListener(OnSwitch);
    }

    public void ChangeSoundorVibrator(bool on)
    {
        if(settingT == SettingT.VIBRATOR)
        {
            if (on)
            {
                SettingControll.Instance.VibratorCheck = 1;
            }
            else
            {
                SettingControll.Instance.VibratorCheck = 0;
            }
        }
        else
        {
            if (on)
            {
                SettingControll.Instance.SoundCheck = 1;
            }
            else
            {
                SettingControll.Instance.SoundCheck = 0;
            }
        }
    }
}
