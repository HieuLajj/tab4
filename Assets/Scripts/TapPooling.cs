using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class TapPooling : Singleton<TapPooling>
{
    public GameObject pregabTap;
   

    public Material materialTarget;
    
    private void Start()
    {
        Controller.Instance.IndexTap = PlayerPrefs.GetInt("TapIndex");
        SetupFirst();
    }

    public GameObject GetTap()
    {
        int count = transform.childCount;
        for(int i=0; i< count; i++)
        {
            if (!transform.GetChild(i).gameObject.activeInHierarchy)
            {
                if (!string.IsNullOrEmpty(Controller.Instance.TagNameTag))
                {
                    if (transform.GetChild(i).CompareTag(Controller.Instance.TagNameTag))
                    {
   
                        return transform.GetChild(i).gameObject;
                    }
                }
            }
        }
        return Instantiate(pregabTap, transform);
    }

    public void CreateTap( Vector3 position)
    {
        if (pregabTap == null) { return; }
       
        GameObject obj = GetTap();
        if (!obj.activeInHierarchy)
        {
            obj.SetActive(true);
        }
        if(materialTarget != null)
        {
            obj.GetComponent<TapparticleElement>().SetUp(materialTarget);
        }
        position.z = 5;
        Vector3 positionMouse = Camera.main.ScreenToWorldPoint(position);
        positionMouse.z = Camera.main.transform.position.z + 5 ;
        obj.transform.position = positionMouse;
    }

    private void SetupFirst()
    {
        TapItemData tapItem = LevelManager.Instance.tapdata.GetTapData(Controller.Instance.IndexTap);
        pregabTap = tapItem.TapObject;
        materialTarget = tapItem.materialTap;
        if (tapItem.TapObject == null)
        {
            return;
        }
        string tagname;
        if (!string.IsNullOrEmpty(tapItem.TapObject.tag))
        {
            tagname = tapItem.TapObject.tag;
        }
        else
        {
            tagname = "";
        }
        Controller.Instance.TagNameTag = tagname;
    }
}
