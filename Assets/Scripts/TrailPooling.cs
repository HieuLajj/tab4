using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailPooling : Singleton<TrailPooling>
{
    public GameObject PrefabsTrail;

    private void Start()
    {
        Controller.Instance.IndexTrail = PlayerPrefs.GetInt("TrailIndex");
        SetupFirst();
    }
    public GameObject GetTrail()
    {
        if (PrefabsTrail == null) return null;
        int count = transform.childCount;
        for(int i = 0; i < count; i++)
        {
            if (!transform.GetChild(i).gameObject.activeInHierarchy)
            {
                if (!string.IsNullOrEmpty(Controller.Instance.TrailsObjectTarget))
                {
                    if (transform.GetChild(i).CompareTag(Controller.Instance.TrailsObjectTarget))
                    {
                        return transform.GetChild(i).gameObject;
                    }
                }
            }
        }
        return Instantiate(PrefabsTrail);
    }

    private void SetupFirst()
    {
        TrailsItemData trailsItem = LevelManager.Instance.materialdata.GetSkinData(Controller.Instance.IndexTrail);
        Controller.Instance.TrailsObjectTarget = trailsItem.NameTag;
        TrailPooling.Instance.PrefabsTrail = trailsItem.Particle;
    }
}
