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

    private bool SkinCoroutineCheck = false;
    private bool TapCoroutineCheck = false;
    private bool TrailCoroutineCheck = false;

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
        if (Controller.Instance.gameState == StateGame.AWAITLOAD || UIManager.Instance.SelectHomeUI.activeInHierarchy || Controller.Instance.gameState == StateGame.AWAITNEW) return;
        if (Controller.Instance)
        {
            Controller.Instance.gameState = StateGame.PLAY;
        }
        UIManager.Instance.UIBoom?.GetComponent<BoomBtn>().HienUIBoom();
        UIManager.Instance.GameUIIngame.CoinsUI.SetActive(false);
    }

    public void RanDomShop()
    {
        if(SkinCoroutineCheck){return;}
        StartCoroutine(RandomShop());
    }

    public void RandomTapShop()
    {
        if(TapCoroutineCheck){return;}
        StartCoroutine(RandomTap());
    }

    public void RandomTrailShop()
    {
        if(TrailCoroutineCheck){return;}
        StartCoroutine(RandomTrail());
    }
    IEnumerator RandomShop()
    {
        float time = 0;
        ButtonChangeSkin buttonChangeMaterial;
        SkinCoroutineCheck = true;
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
        yield return new WaitForSeconds(1f);
        if (ButtonchangeSkinTarget != null)
        {
            ButtonchangeSkinTarget.Save();
            Controller.Instance.RemoveSkinMaterialMemory(ButtonchangeSkinTarget);
            //ButtonchangeSkinTarget.backgroundImage.color = Color.white;
            ButtonchangeSkinTarget.backgroundImage.enabled = false;
        }
        SkinCoroutineCheck = false;
    }


    IEnumerator RandomTap()
    {
        float time = 0;
        ButtonChangeTap buttonChangeTap;
        TapCoroutineCheck = true;
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
        yield return new WaitForSeconds(1f);
        if (ButtonchangeTapTarget != null)
        {
            ButtonchangeTapTarget.Save();
            Controller.Instance.RemoveTapMaterialMemory(ButtonchangeTapTarget);
            //ButtonchangeSkinTarget.backgroundImage.color = Color.white;
            ButtonchangeTapTarget.backgroundImage.enabled = false;
        }
        TapCoroutineCheck = false;
    }

    IEnumerator RandomTrail()
    {
        float time = 0;
        ButtonChangeTrails buttonChangeTrail;
        TrailCoroutineCheck = true;
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
        yield return new WaitForSeconds(1f);
        if (ButtonchangeTrailsTarget != null)
        {
            ButtonchangeTrailsTarget.Save();
            Controller.Instance.RemoveTrailMaterialMemory(ButtonchangeTrailsTarget);
            //ButtonchangeSkinTarget.backgroundImage.color = Color.white;
            ButtonchangeTrailsTarget.backgroundImage.enabled = false;
        }
        TrailCoroutineCheck = false;
    }

    public void AddCoin()
    {
        Controller.Instance.CoinPlayer += 300;
    }
}
