using DG.Tweening;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test3 : Singleton<Test3>
{
    public GameObject PrefabsGift;
    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.K))
        {
            // Debug.Log("Space key was pressed.");
            GameObject g = LevelManager.Instance.GetRandomGift();
           
            //});
            if (g != null)
            {
                Block block = g.GetComponent<Block>();
                block.StatusBlock = StatusBlock.Gift;
            }
           // block.ModelBlock.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Controller.Instance.ChangSkin(2);
        }
    }
}
