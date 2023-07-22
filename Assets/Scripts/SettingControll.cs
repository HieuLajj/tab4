using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SettingT
{
    SOUND,
    VIBRATOR
}
public class SettingControll : Singleton<SettingControll>
{

    private int soundCheck;
    public int SoundCheck
    {
        set { 
            soundCheck = value;
            PlayerPrefs.SetInt("SoundCheck",value);
        }
        get { return soundCheck; }
    }

    private int vibratorCheck;
    public int VibratorCheck
    {
        set
        {
            vibratorCheck = value;
            PlayerPrefs.SetInt("VibratorCheck", value);
        }
        get { return vibratorCheck;
            
        }
    }
    public SettinUI settingUI;
    private void Start()
    {
        if (PlayerPrefs.HasKey("SoundCheck") || PlayerPrefs.HasKey("SoundCheck"))
        {
            SoundCheck = PlayerPrefs.GetInt("SoundCheck");
            VibratorCheck = PlayerPrefs.GetInt("VibratorCheck");
        }
        else
        {
            SoundCheck = 1;
            VibratorCheck = 1;
        }
        
    }

    public void ActiveShop(){
        UIManager.Instance.SelectShopUI.SetActive(true);
    }

    public void Back(){      
        settingUI.PanelSetting.SetActive(false);
        if(Controller.Instance.gameState == StateGame.AWAITNEW){
            UIManager.Instance.CompleteLevelUI.SetActive(true);
        }
    }

}
