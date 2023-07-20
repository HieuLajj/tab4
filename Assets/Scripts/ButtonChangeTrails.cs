using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChangeTrails : ButtonChange
{
    public TrailsItemData trailsData;

    private void Awake()
    {
        flag = Controller.Instance.constantsShop[ShopEnum.TRAILS] + index;
    }
    public override void Setup()
    {
        trailsData = LevelManager.Instance.materialdata.GetSkinData(index);
        SetData(flag);
       
    }
    public override void UpdateView(int id)
    {
        if (trailsData.Particle == null)
        {
            if(trailsData.Particle == null)
            {
                image.enabled = false;
            }
            else
            {
                image.enabled = true;
            }
            image.sprite = trailsData.AnhImage;
            TextPrice.transform.parent.gameObject.SetActive(false);
            checkActive = ButtonEnum.ACTIVE;
            return;
        }

        var isOwned = DataPlayer.IdCheckData(id);
        if (isOwned)
        {
            image.sprite = trailsData.AnhImage;
            TextPrice.transform.parent.gameObject.SetActive(false);
            checkActive = ButtonEnum.ACTIVE;
        }
        else
        {
            if (trailsData.Price != 0)
            {
                image.sprite = trailsData.AnhImage;
                TextPrice.transform.parent.gameObject.SetActive(true);
                TextPrice.text = trailsData.Price.ToString();
                checkActive = ButtonEnum.PRICE;
            }
            else
            {
                image.sprite = spriteNotPrice;
                TextPrice.transform.parent.gameObject.SetActive(false);
                checkActive = ButtonEnum.NOT;
                //if (tagName == "SKIN")
                //{
                Controller.Instance.AddTrailMaterialMemory(this);
                //}
            }
        }
    }

    public override void ClickChange()
    {
        if (checkActive == ButtonEnum.PRICE)
        {
            if (Controller.Instance.CoinPlayer >= trailsData.Price)
            {
                NotifiSystem.Instance.NotifiString("Successfully Purchase!");           
                Controller.Instance.CoinPlayer -= trailsData.Price;
                Save();
            }
            else
            {
                NotifiSystem.Instance.NotifiString("You need more coins!");
            }
            return;
        }
        if (checkActive != ButtonEnum.ACTIVE) return;

        // sua nha
        //Controller.Instance.TrailsObjectTarget = trailsData.NameTag;
        
        Controller.Instance.IndexTrail = index;

        if(trailsData.Particle == null)
        {
            TrailPooling.Instance.PrefabsTrail = null;

            TrailPooling.Instance.TrailName = null;
            return;
        }
        Controller.Instance.TrailsObjectTarget = trailsData.Particle.tag;
        TrailPooling.Instance.PrefabsTrail = trailsData;

        TrailPooling.Instance.TrailName = trailsData.StringSprite;
    }
}
