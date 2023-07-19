using UnityEngine;
using UnityEngine.UI;
using EasyUI.Tabs;
using Unity.VisualScripting;
using DG.Tweening.Core.Easing;
using EnhancedUI.EnhancedScroller;
using EnhancedScrollerDemos;
using EnhancedScrollerDemos.GridSelection;

public class TabsUIHorizontal : TabsUI
{
    #if UNITY_EDITOR
    private void Reset() {
        OnValidate();
    }
    private void OnValidate() {
        base.Validate(TabsType.Horizontal);
    }
#endif
    private static TabsUIHorizontal instance;
    public static TabsUIHorizontal Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<TabsUIHorizontal>();
            }
            return instance;
        }
        private set
        {
            instance = value;
        }
    }
    //public NumberLevelManager numberLevelManager;
    //public GameObject NumberLevel;

    public GameObject NewPanelLevel;
    public GameObject PreTarget;
    public EnhancedScrollerDemos.GridSelection.ControllerScrollview controllerScrollview;
    //private void Awake()
    //{
    //    numberLevelManager = transform.GetComponent<NumberLevelManager>();
    //}

    private void OnEnable()
    {
        tabContent[current].GetComponent<TabContain>().SetUp();
        //numberLevelManager.ActiveLoadLevel(current);
        controllerScrollview.MaxCellLevel = GetMaxCell(current);
        PreTarget = tabContent[current];
    }

    public override void OnTabButtonClicked(int tabIndex)
    {
        if (current != tabIndex)
        {
            if (OnTabChange != null)
                OnTabChange.Invoke(tabIndex);
            if (controllerScrollview.transform.parent.gameObject.activeInHierarchy)
            {
                controllerScrollview.transform.parent.gameObject.SetActive(false);
            }
            

            previous = current;
            current = tabIndex;

            tabContent[previous].SetActive(false);
            tabContent[current].SetActive(true);

            tabBtns[previous].uiImage.color = tabColorInactive;
            tabBtns[current].uiImage.color = tabColorActive;

            tabBtns[previous].uiButton.interactable = true;
            tabBtns[current].uiButton.interactable = false;

            //numberLevelManager.ActiveLoadLevel(tabIndex);
            controllerScrollview.MaxCellLevel = GetMaxCell(tabIndex);


            tabBtns[previous].uiButton.GetComponent<TabButtonUI>().DisActive();
            tabBtns[current].uiButton.GetComponent<TabButtonUI>().Active();
            tabContent[current].GetComponent<TabContain>().SetUp();

            PreTarget = tabContent[current];
            //numberLevelManager.gameObject.SetActive(false);
            //controllerScrollview.transform.parent.gameObject.SetActive(false);

        }
    }

    public int GetMaxCell(int level)
    {
        if (level == 0)
        {
            Controller.Instance.DiffirentGame = DiffirentEnum.EASY;
        }
        else if (level == 1)
        {
            Controller.Instance.DiffirentGame = DiffirentEnum.MEDIUM;
        }
        else if (level == 2)
        {
            Controller.Instance.DiffirentGame = DiffirentEnum.HARD;
        }        
        return Controller.Instance.constantsDiffical[Controller.Instance.DiffirentGame];
    }
}
