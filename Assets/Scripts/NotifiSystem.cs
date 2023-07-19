using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NotifiSystem : Singleton<NotifiSystem>
{

    public TextMeshProUGUI TextNotifi;
    public void NotifiString( string str){
        TextNotifi.text = str;
        StartCoroutine(ShowNotification());
    }
    private IEnumerator ShowNotification(){
        TextNotifi.enabled = true;
        yield return new WaitForSeconds(2f); 
        TextNotifi.enabled = false;      
    }

}
