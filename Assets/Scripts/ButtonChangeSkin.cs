using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChangeSkin : ButtonChange
{
    private SkinItemData skinData;

    private void Awake()
    {
        flag = Controller.Instance.constantsShop[ShopEnum.SKIN] + index;
    }


    public override void Setup()
    {
        skinData = LevelManager.Instance.skindata.GetSkinData(index);
        SetData(flag);
    }

    public override void UpdateView(int id)
    {
        if(id == Controller.Instance.constantsShop[ShopEnum.SKIN])
        {
            image.sprite = skinData.AnhImage;
            TextPrice.transform.parent.gameObject.SetActive(false);
            checkActive = ButtonEnum.ACTIVE;
            return;
        }

        var isOwned = DataPlayer.IdCheckData(id);
        if (isOwned)
        {
            image.sprite = skinData.AnhImage;
            TextPrice.transform.parent.gameObject.SetActive(false);
            checkActive = ButtonEnum.ACTIVE;
        }
        else
        {
            if (skinData.Price != 0)
            {
                image.sprite = skinData.AnhImage;
                TextPrice.transform.parent.gameObject.SetActive(true);
                TextPrice.text = skinData.Price.ToString();
                checkActive = ButtonEnum.PRICE;
            }
            else
            {
                image.sprite = spriteNotPrice;
                TextPrice.transform.parent.gameObject.SetActive(false);
                checkActive = ButtonEnum.NOT;
                //if (tagName == "SKIN")
                //{
                Controller.Instance.AddSkinMaterialMemory(this);
                //}
            }
        }
    }

    public override void ClickChange()
    {
        if (checkActive == ButtonEnum.PRICE)
        {
            //int coinPlayer = PlayerPrefs.GetInt("Coin");
            if (Controller.Instance.CoinPlayer >= skinData.Price)
            {
                NotifiSystem.Instance.NotifiString("Successfully Purchase!");
                //PlayerPrefs.SetInt("Coin", coinPlayer-skinData.Price);
                Controller.Instance.CoinPlayer -= skinData.Price;
                Save();
            }
            else
            {
                NotifiSystem.Instance.NotifiString("You need more coins!");
            }
            return;
        }
        if (checkActive != ButtonEnum.ACTIVE) return;
        Controller.Instance.ChangSkin(Controller.Instance.constantsShop[ShopEnum.SKIN] + index);
    }
}
