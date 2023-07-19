using UnityEngine;
using UnityEngine.UI;
using EasyUI.Tabs;
using Unity.VisualScripting;
using DG.Tweening.Core.Easing;

public class TabsUIHorizontal2 : TabsUI
{
#if UNITY_EDITOR
    private void Reset()
    {
        OnValidate();
    }
    private void OnValidate()
    {
        base.Validate(TabsType.Horizontal);
    }
#endif
    private static TabsUIHorizontal2 instance;
    public static TabsUIHorizontal2 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<TabsUIHorizontal2>();
            }
            return instance;
        }
        private set
        {
            instance = value;
        }
    }
   
  

    public override void OnTabButtonClicked(int tabIndex)
    {
        if (current != tabIndex)
        {
            if (OnTabChange != null)
                OnTabChange.Invoke(tabIndex);
         

            previous = current;
            current = tabIndex;

            tabContent[previous].SetActive(false);
            tabContent[current].SetActive(true);

            tabBtns[previous].uiImage.color = tabColorInactive;
            tabBtns[current].uiImage.color = tabColorActive;

            tabBtns[previous].uiButton.interactable = true;
            tabBtns[current].uiButton.interactable = false;

          


            tabBtns[previous].uiButton.GetComponent<TabButtonUI>().DisActive();
            tabBtns[current].uiButton.GetComponent<TabButtonUI>().Active();
           

            
        }
    }
}
