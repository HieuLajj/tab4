using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : UIFuctionUltiliti
{
    private static ShopUI instance;
    public static ShopUI Instance{
    get{
            if(instance == null){
                instance = FindObjectOfType<ShopUI>();
            }
            return instance;
        }
        private set{
            instance = value;
        }   
    }
    public static ButtonChangeSkin ButtonchangeSkinTarget;
    public static ButtonChangeTap ButtonchangeTapTarget;
    public static ButtonChangeTrails ButtonchangeTrailsTarget;

    private void OnEnable() {
        Controller.Instance.gameState = StateGame.AWAIT;
        UIManager.Instance.UIBoom?.GetComponent<BoomBtn>().AnUIBoom();
        UIManager.Instance.GameUIIngame.CoinsUI.SetActive(true);

        if(ButtonchangeSkinTarget != null)
        {
            //ButtonchangeSkinTarget.backgroundImage.color = Color.white;
            ButtonchangeSkinTarget.backgroundImage.enabled = false;
        }

        if(ButtonchangeTapTarget != null)
        {
            ButtonchangeTapTarget.backgroundImage.enabled = false;
        }
    }

    private void OnDisable() {
        if (Controller.Instance)
        {
            Controller.Instance.gameState = StateGame.PLAY;
        }
        UIManager.Instance.UIBoom?.GetComponent<BoomBtn>().HienUIBoom();
        UIManager.Instance.GameUIIngame.CoinsUI.SetActive(false);
    }

    public void RanDomShop()
    {
        StartCoroutine(RandomShop());
    }

    public void RandomTapShop()
    {
        StartCoroutine(RandomTap());
    }

    public void RandomTrailShop()
    {
        StartCoroutine(RandomTrail());
    }
    IEnumerator RandomShop()
    {
        float time = 0;
        ButtonChangeSkin buttonChangeMaterial;
        while (time<10)
        {
            time += 20 * Time.deltaTime;
           
            yield return new WaitForSeconds(0.25f);
            buttonChangeMaterial = Controller.Instance.SelectRandomSkin();

            if (buttonChangeMaterial == null) break;
            //reset mau target
            if(ButtonchangeSkinTarget != null)
            {
                //ButtonchangeSkinTarget.backgroundImage.color = Color.white;
                ButtonchangeSkinTarget.backgroundImage.enabled = false;
            }
            //buttonChangeMaterial.backgroundImage.color = Color.yellow;
            buttonChangeMaterial.backgroundImage.enabled = true;
            ButtonchangeSkinTarget = buttonChangeMaterial;

        }
        if (ButtonchangeSkinTarget != null)
        {
            ButtonchangeSkinTarget.Save();
            Controller.Instance.RemoveSkinMaterialMemory(ButtonchangeSkinTarget);
            //ButtonchangeSkinTarget.backgroundImage.color = Color.white;
            ButtonchangeSkinTarget.backgroundImage.enabled = false;
        }
    }


    IEnumerator RandomTap()
    {
        float time = 0;
        ButtonChangeTap buttonChangeTap;
        while (time < 10)
        {
            time += 20 * Time.deltaTime;

            yield return new WaitForSeconds(0.25f);
            buttonChangeTap = Controller.Instance.SelectRandomTap();

            if (buttonChangeTap == null) break;
            //reset mau target
            if (ButtonchangeTapTarget != null)
            {
                //ButtonchangeSkinTarget.backgroundImage.color = Color.white;
                ButtonchangeTapTarget.backgroundImage.enabled = false;
            }
            //buttonChangeMaterial.backgroundImage.color = Color.yellow;
            buttonChangeTap.backgroundImage.enabled = true;
            ButtonchangeTapTarget = buttonChangeTap;

        }
        if (ButtonchangeTapTarget != null)
        {
            ButtonchangeTapTarget.Save();
            Controller.Instance.RemoveTapMaterialMemory(ButtonchangeTapTarget);
            //ButtonchangeSkinTarget.backgroundImage.color = Color.white;
            ButtonchangeTapTarget.backgroundImage.enabled = false;
        }
    }

    IEnumerator RandomTrail()
    {
        float time = 0;
        ButtonChangeTrails buttonChangeTrail;
        while (time < 10)
        {
            time += 20 * Time.deltaTime;

            yield return new WaitForSeconds(0.25f);
            buttonChangeTrail = Controller.Instance.SelectRandomTrail();

            if (buttonChangeTrail == null) break;
            //reset mau target
            if (ButtonchangeTrailsTarget != null)
            {
                //ButtonchangeSkinTarget.backgroundImage.color = Color.white;
                ButtonchangeTrailsTarget.backgroundImage.enabled = false;
            }
            //buttonChangeMaterial.backgroundImage.color = Color.yellow;
            buttonChangeTrail.backgroundImage.enabled = true;
            ButtonchangeTrailsTarget = buttonChangeTrail;

        }
        if (ButtonchangeTrailsTarget != null)
        {
            ButtonchangeTrailsTarget.Save();
            Controller.Instance.RemoveTrailMaterialMemory(ButtonchangeTrailsTarget);
            //ButtonchangeSkinTarget.backgroundImage.color = Color.white;
            ButtonchangeTrailsTarget.backgroundImage.enabled = false;
        }
    }

    public void AddCoin()
    {
        Controller.Instance.CoinPlayer += 300;
    }
}
