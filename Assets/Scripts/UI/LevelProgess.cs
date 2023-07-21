using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using static UnityEngine.Rendering.DebugUI;
using System;
using Random = UnityEngine.Random;
public class LevelProgess : MonoBehaviour
{
    public Image ImageNode1;
    public Image ImageNode2;
    public Image ImageProgess;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;

    public UIGradient uigradient;
    private static LevelProgess instance;
    public static LevelProgess Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<LevelProgess>();
            }
            return instance;
        }
        private set
        {
            instance = value;
        }
    }
    private int levelIngamePlayer;
    public int LevelInGamePlayer
    {
        set { 
            levelIngamePlayer = value;
            PlayerPrefs.SetInt("LevelInGamePlayer", levelIngamePlayer);
        }
        get
        {
            return levelIngamePlayer;
        }
    }
    public int stackLevelInGame;
    public int StackLevelInGame
    {
        set
        {
            stackLevelInGame = value;
            PlayerPrefs.SetInt("StackLevelInGame", stackLevelInGame);
        }
        get
        {
            return stackLevelInGame;
        }
    }
    private void Start()
    {
        Setup();
    }
    public void ChangeColor()
    {
        Color[] colors = new Color[] {
            Color.red,
            Color.green,
            Color.blue,
            Color.yellow,
            Color.cyan,
            Color.magenta,
            Color.gray
        };

        Color color1 = Color.white;
        Color color2 = Color.white;

        while (color1 == color2 || color1 == Color.white || color2 == Color.white)
        {
            color1 = colors[Random.Range(0, colors.Length)];
            color2 = colors[Random.Range(0, colors.Length)];
        }

        ImageNode1.color = color1;
        ImageNode2.color = color2;
        uigradient.m_color1 = color2;
        uigradient.m_color2 = color1;
    }

    //void OnGUI()
    //{
    //    if (GUI.Button(new Rect(250, 10, 150, 100), "tang level"))
    //    {
    //        UpdateUI();
    //    }
      
    //}

    public void UpdateUI()
    {
        StackLevelInGame+=1;
      
        float value2 =(float) StackLevelInGame / ( (LevelInGamePlayer+1) * 3);
       
        ImageProgess.DOFillAmount(value2, 1f).OnComplete(() =>
        {
            if (value2 >= 1)
            {
                ResetLevelUp();
            }
        });
        
    }

    public void ResetLevelUp()
    {
        LevelInGamePlayer+=1;
        StackLevelInGame = 0;

        text1.text = LevelInGamePlayer.ToString();
        text2.text = (LevelInGamePlayer + 1) + "";

        uigradient.m_color1 = Color.white;
        uigradient.m_color2 = Color.white;
        ImageProgess.fillAmount = 0;
        ChangeColor();
    }

    public void Setup()
    {
        levelIngamePlayer = PlayerPrefs.GetInt("LevelInGamePlayer");
        StackLevelInGame = PlayerPrefs.GetInt("StackLevelInGame");
        ChangeColor();
        text1.text = levelIngamePlayer.ToString();
        text2.text = (levelIngamePlayer + 1)+"";
        float value3 =(float) StackLevelInGame / ((LevelInGamePlayer+1) * 3);
       
        ImageProgess.fillAmount = value3;
    }
}
