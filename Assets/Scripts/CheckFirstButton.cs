using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFirstButton : MonoBehaviour
{
   
    public GameObject Notifi;
    private int checkFirst;
    public int CheckFirst{
        set{
            checkFirst = value;
            if(checkFirst == 0){
                Notifi.gameObject.SetActive(true);
            }else{
                Notifi.gameObject.SetActive(false);
            }
        }
        get{
            return checkFirst;
        }
    }
    public void Check(){
        CheckFirst = PlayerPrefs.GetInt("gameObjectUI"+transform.gameObject.GetInstanceID());
    }
}
