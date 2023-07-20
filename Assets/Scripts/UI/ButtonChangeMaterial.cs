using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public enum ButtonEnum{
    ACTIVE,
    PRICE,
    NOT
}
public class ButtonChangeMaterial : MonoBehaviour
{
    public int index;
    public Image image;
    public TextMeshProUGUI TextPrice;
    public Sprite spriteNotPrice;


    private SkinItemData skinData;
    private TrailsItemData trailsData;
    private TapItemData tapData;

    private ButtonEnum checkActive = ButtonEnum.NOT;
    public Image backgroundImage;
    private string tagName = null;
    private void Start()
    {
        tagName = gameObject.tag;
        SetUp();
    }

   

    public void ClickChangeMaterial()
    {
        if(checkActive == ButtonEnum.PRICE){
            //int coinPlayer = PlayerPrefs.GetInt("Coin");
            if(Controller.Instance.CoinPlayer >= skinData.Price){
                NotifiSystem.Instance.NotifiString("Successfully Purchase!");
                //PlayerPrefs.SetInt("Coin", coinPlayer-skinData.Price);
                Controller.Instance.CoinPlayer -= skinData.Price;
                DataPlayer.AddCar(Controller.Instance.constantsShop[ShopEnum.SKIN]+index);
                SetData(Controller.Instance.constantsShop[ShopEnum.SKIN]+index);
                //checkActive = ButtonEnum.ACTIVE;
            }else{
                NotifiSystem.Instance.NotifiString("You need more coins!");
            }
            return;
        }
        if(checkActive != ButtonEnum.ACTIVE) return;
        if (tagName =="SKIN")
        {
            Controller.Instance.ChangSkin(Controller.Instance.constantsShop[ShopEnum.SKIN] + index);
        }else if (tagName == "TRAIL"){
            Controller.Instance.TrailsObjectTarget = trailsData.Particle.tag;
            Controller.Instance.IndexTrail = index;
            //save trails
            //PlayerPrefs.SetString("TrailsObjectTarget", trailsData.NameTag);
            
            
            TrailPooling.Instance.PrefabsTrail = trailsData;
        }else if (tagName == "TAP")
        {
            Controller.Instance.IndexTap = index;
            TapPooling.Instance.pregabTap = tapData.TapObject;
            TapPooling.Instance.materialTarget = tapData.materialTap;
            
            if(tapData.TapObject == null)
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
    public void SetData(int id){
        UpdateView(id);
    }
    public void UpdateView(int id){

        //if(id == 0 || id == 50 || id == 100)
        //{
        //    image.sprite = trailsData.AnhImage;
        //    TextPrice.gameObject.SetActive(false);
        //    checkActive = ButtonEnum.ACTIVE;
        //    return;
        //}

        var isOwned =  DataPlayer.IdCheckData(id);
        if (gameObject.CompareTag("TRAIL"))
        {
            image.sprite = trailsData.AnhImage;
            TextPrice.gameObject.SetActive(false);
            checkActive = ButtonEnum.ACTIVE;
            return;
        }

        if (gameObject.CompareTag("TAP"))
        {
            image.sprite = tapData.AnhImage;
            TextPrice.gameObject.SetActive(false);
            checkActive = ButtonEnum.ACTIVE;
            return;
        }

        if (isOwned){

          
            image.sprite = skinData.AnhImage; 
            TextPrice.gameObject.SetActive(false);
            checkActive = ButtonEnum.ACTIVE;
        }
        else
        {
            if (skinData.Price != 0)
            {
                image.sprite = skinData.AnhImage;
                TextPrice.gameObject.SetActive(true);
                TextPrice.text = skinData.Price.ToString();
                checkActive = ButtonEnum.PRICE;
            }
            else
            {
                image.sprite = spriteNotPrice;
                TextPrice.gameObject.SetActive(false);
                checkActive = ButtonEnum.NOT;
                if (tagName == "SKIN")
                {
                    //Controller.Instance.AddSkinMaterialMemory(this);
                }
            }
        }
    }

    public void SaveSkin()
    {
        DataPlayer.AddCar(Controller.Instance.constantsShop[ShopEnum.SKIN] + index);
        SetData(Controller.Instance.constantsShop[ShopEnum.SKIN] + index);
    }

    public void SetUp()
    {
        if (tagName == "SKIN")
        {
            skinData = LevelManager.Instance.skindata.GetSkinData(index);
            SetData(Controller.Instance.constantsShop[ShopEnum.SKIN] + index);
        }
        else if(tagName == "TRAIL")
        {
            trailsData = LevelManager.Instance.materialdata.GetSkinData(index);
            SetData(Controller.Instance.constantsShop[ShopEnum.TRAILS] + index);
        }
        else if (tagName == "TAP")
        {
            tapData = LevelManager.Instance.tapdata.GetTapData(index);
            SetData(Controller.Instance.constantsShop[ShopEnum.TOUCH] + index);
        }
    }
}
