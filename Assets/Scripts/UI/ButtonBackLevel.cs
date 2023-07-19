using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBackLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject UILevel;
    public GameObject SelectLevel;
    public void Back()
    {
        if (SelectLevel.activeInHierarchy)
        {
            SelectLevel.SetActive(false);
            TabsUIHorizontal.Instance.PreTarget.gameObject.SetActive(true);
            return;
        }
        if (UILevel.activeInHierarchy)
        {
            transform.parent.gameObject.SetActive(false);
            //Controller.Instance.gameState = StateGame.PLAY;
        }
    }

    public void Back2()
    {
        transform.parent.gameObject.SetActive(false);
        //Controller.Instance.gameState = StateGame.PLAY;
    }

    public void Back3()
    {
        Transform transform1 = transform.parent;
        transform1.parent.gameObject.SetActive(false);
    }
}
