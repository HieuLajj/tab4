using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonChange : MonoBehaviour
{
    // Start is called before the first frame update
    public int index;
    public Image image;
    public TextMeshProUGUI TextPrice;
    public Sprite spriteNotPrice;

    public ButtonEnum checkActive = ButtonEnum.NOT;
    public Image backgroundImage;

    public int flag;
    void Start()
    {      
        Setup();
    }

    public abstract void ClickChange();

    public void SetData(int id)
    {
        UpdateView(id);
    }

    public abstract void UpdateView(int id);

    public abstract void Setup();

    public void Save()
    {
        DataPlayer.AddCar(flag);
        SetData(flag);
    }
}
