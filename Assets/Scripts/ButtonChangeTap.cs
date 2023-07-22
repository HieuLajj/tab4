using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChangeTap : ButtonChange
{
    private TapItemData tapData;
    public CheckFirstButton checkFirstButton;
    private void Awake()
    {
        flag = Controller.Instance.constantsShop[ShopEnum.TOUCH] + index;
    }
    public override void Setup()
    {
        tapData = LevelManager.Instance.tapdata.GetTapData(index);
        SetData(flag);
    }

    public override void UpdateView(int id)
    {
       // if (id == Controller.Instance.constantsShop[ShopEnum.TOUCH])
       // {
       if(tapData.TapObject == null)
       {
            if (tapData.TapObject == null)
            {
                image.enabled = false;
            }
            else
            {
                image.enabled = true;
            }
            image.sprite = tapData.AnhImage;
            TextPrice.transform.parent.gameObject.SetActive(false);
            checkActive = ButtonEnum.ACTIVE;
             //checkFirstButton.Check();
            return;
        }      
       // }

        var isOwned = DataPlayer.IdCheckData(id);
        if (isOwned)
        {
            image.sprite = tapData.AnhImage;
            TextPrice.transform.parent.gameObject.SetActive(false);
            checkActive = ButtonEnum.ACTIVE;
             checkFirstButton.Check();
        }
        else
        {
            if (tapData.Price != 0)
            {
                image.sprite = tapData.AnhImage;
                TextPrice.transform.parent.gameObject.SetActive(true);
                TextPrice.text = tapData.Price.ToString();
                checkActive = ButtonEnum.PRICE;
            }
            else
            {
                image.sprite = spriteNotPrice;
                TextPrice.transform.parent.gameObject.SetActive(false);
                checkActive = ButtonEnum.NOT;
                //if (tagName == "SKIN")
                //{
                Controller.Instance.AddTapMaterialMemory(this);
                //}
            }
        }
    }

    public override void ClickChange()
    {
        if (checkActive == ButtonEnum.PRICE)
        {
            if (Controller.Instance.CoinPlayer >= tapData.Price)
            {
                NotifiSystem.Instance.NotifiString("Successfully Purchase!");
                Controller.Instance.CoinPlayer -= tapData.Price;
                Save();
            }
            else
            {
                NotifiSystem.Instance.NotifiString("You need more coins!");
            }
            return;
        }
        if (checkActive != ButtonEnum.ACTIVE) return;

        Controller.Instance.IndexTap = index;
        TapPooling.Instance.pregabTap = tapData.TapObject;
        TapPooling.Instance.materialTarget = tapData.materialTap;
        if(checkFirstButton.CheckFirst==0){
            PlayerPrefs.SetInt("gameObjectUI"+transform.gameObject.GetInstanceID(),1);
            checkFirstButton.CheckFirst = 1;
        }

        if (tapData.TapObject == null)
        {
            return;
        }
        string tagname;
        if (!string.IsNullOrEmpty(tapData.TapObject.tag))
        {
            tagname = tapData.TapObject.tag;
        }
        else
        {
            tagname = "";
        }
        Controller.Instance.TagNameTag = tagname;
    }
}
