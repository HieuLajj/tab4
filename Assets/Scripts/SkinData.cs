using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ScriptableObject", menuName = "SkinData")]
public class SkinData : ScriptableObject
{
    public List<SkinItemData> Datas = new List<SkinItemData>();

    public Material GetItem(int index)
    {
        {
            SkinItemData itemData = Datas[index];
            return itemData.skinMaterials;
        }
    }
    public SkinItemData GetSkinData(int index) { 
        return Datas[index];
    }
}
[System.Serializable]
public class SkinItemData
{
    public int Id;
    public Material skinMaterials;
    public Color colorSkin;
    public Sprite AnhImage;
    public int Price;
}
