using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailPooling : Singleton<TrailPooling>
{
    public TrailsItemData PrefabsTrail;
    public string TrailName;

    private void Start()
    {
        Controller.Instance.IndexTrail = PlayerPrefs.GetInt("TrailIndex");
        SetupFirst();
    }
    public GameObject GetTrailpre()
    {
        if (PrefabsTrail == null) return null;
        if (PrefabsTrail.Particle == null) return null;
        int count = transform.childCount;
        for (int i = 0; i < count; i++)
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
        return Instantiate(PrefabsTrail.Particle);
    }
    public GameObject GetTrail()
    {
        GameObject trail = GetTrailpre();
        if(TrailName != null)
        {
            Sprite sprite = ControlSpriteAtlas.Instance.AtlasTrail.GetSprite(TrailName);
            if(sprite == null) { return trail; }
            TrailparticleElement trailetc =  trail.GetComponent<TrailparticleElement>();
            trailetc.Setup(sprite, PrefabsTrail.Id);

        }
        return trail;
    }

    private void SetupFirst()
    {
        TrailsItemData trailsItem = LevelManager.Instance.materialdata.GetSkinData(Controller.Instance.IndexTrail);
        if(trailsItem.Particle == null) return;
        Controller.Instance.TrailsObjectTarget = trailsItem.Particle.tag;
        TrailPooling.Instance.PrefabsTrail = trailsItem;
    }
}
