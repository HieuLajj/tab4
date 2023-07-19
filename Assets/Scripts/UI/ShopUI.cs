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
    public static ButtonChangeMaterial ButtonchangeSkinTarget;
    
    private void OnEnable() {
        Controller.Instance.gameState = StateGame.AWAIT;
        UIManager.Instance.UIBoom?.GetComponent<BoomBtn>().AnUIBoom();
        UIManager.Instance.GameUIIngame.CoinsUI.SetActive(true);

        if(ButtonchangeSkinTarget != null)
        {
            //ButtonchangeSkinTarget.backgroundImage.color = Color.white;
            ButtonchangeSkinTarget.backgroundImage.enabled = false;
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

    IEnumerator RandomShop()
    {
        float time = 0;
        ButtonChangeMaterial buttonChangeMaterial;
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
        ButtonchangeSkinTarget.SaveSkin();
        Controller.Instance.RemoveSkinMaterialMemory(ButtonchangeSkinTarget);
        //ButtonchangeSkinTarget.backgroundImage.color = Color.white;
        ButtonchangeSkinTarget.backgroundImage.enabled = false;
    }
    
}
