using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettinUI : UIFuctionUltiliti
{
    // Start is called before the first frame update
    public SwitchToggle SoundToggle;
    public SwitchToggle VibrateToggle;
    private void Start()
    { 
        SoundToggle.toggle.isOn = (SettingControll.Instance.SoundCheck == 1) ? true : false;
        VibrateToggle.toggle.isOn = (SettingControll.Instance.VibratorCheck == 1) ? true : false;
    }
}
