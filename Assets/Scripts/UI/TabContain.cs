using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class TabContain : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI textLevel;
    public TextMeshProUGUI textNextLevel;
    public TextMeshProUGUI textTienDo;
    public Image imageFill;
    public Image imageNotifi;
    public Sprite[] spriteImage;
    public GameObject NextPanelGameObject;
    public int flag = 0;
    
    public void SetUp()
    {
        
        if (Controller.Instance.DiffirentGame == DiffirentEnum.EASY)
        {
            flag = 0;
        }
        else if (Controller.Instance.DiffirentGame == DiffirentEnum.MEDIUM)
        {
            flag = 10;
        }
        else if (Controller.Instance.DiffirentGame == DiffirentEnum.HARD)
        {
            flag = 30;
        }
        if (Controller.Instance.DiffirentGame == DiffirentEnum.EASY)
        {
            textLevel.text = $"Levels 1 - {Controller.Instance.constantsDiffical[DiffirentEnum.EASY]}";
        }
        else if (Controller.Instance.DiffirentGame == DiffirentEnum.MEDIUM)
        {
            textLevel.text = $"Levels {Controller.Instance.constantsDiffical[DiffirentEnum.EASY] + 1} - {Controller.Instance.constantsDiffical[DiffirentEnum.MEDIUM]}";
        }
        else if (Controller.Instance.DiffirentGame == DiffirentEnum.HARD)
        {
            textLevel.text = $"Levels {Controller.Instance.constantsDiffical[DiffirentEnum.MEDIUM] + 1} - 300";
        }
        //Debug.Log((LevelManager.Instance.DataDiffical[Controller.Instance.DiffirentGame] - flag) / Controller.Instance.constantsDiffical[Controller.Instance.DiffirentGame]);
        float a = LevelManager.Instance.DataDiffical[Controller.Instance.DiffirentGame] - flag;
        float b = Controller.Instance.constantsDiffical[Controller.Instance.DiffirentGame];
        int c = LevelManager.Instance.DataDiffical[Controller.Instance.DiffirentGame];
        if (c==0){
            c=1+flag;
        }
        textNextLevel.text = $"Level {c}";
        imageFill.fillAmount = a/b;
        if (imageFill.fillAmount >= 1)
        {
            imageNotifi.sprite = spriteImage[0];
            NextPanelGameObject.SetActive(false);
        }
        else
        {
            imageNotifi.sprite = spriteImage[1];
            if (!NextPanelGameObject.activeInHierarchy)
            {
                NextPanelGameObject.SetActive(true);
            }
        }

        textTienDo.text = $" {LevelManager.Instance.DataDiffical[Controller.Instance.DiffirentGame]}/{Controller.Instance.constantsDiffical[Controller.Instance.DiffirentGame]} ";

    }

    public void CallLevelPanel()
    {
        gameObject.SetActive(false);
        //TabsUIHorizontal.Instance.NumberLevel.gameObject.SetActive(true);
        TabsUIHorizontal.Instance.NewPanelLevel.gameObject.SetActive(true);
        


    }

    public void NextLevelEventButton()
    {
        if(UIManager.Instance.SelectHomeUI.activeInHierarchy){
            UIManager.Instance.SelectHomeUI.SetActive(false);
        }
        int c = LevelManager.Instance.DataDiffical[Controller.Instance.DiffirentGame];
        if (c==0){
            c=1+flag;
        }
        LevelManager.Instance.LoadLevelInGame(c);
    }
}
