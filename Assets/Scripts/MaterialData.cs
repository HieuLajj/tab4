using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject", menuName = "TrailsData")]
public class MaterialData : ScriptableObject
{
    public List<TrailsItemData> Datas = new List<TrailsItemData>();
    public GameObject GetItem(int index)
    {
        {
            TrailsItemData itemData = Datas[index];
            return itemData.Particle;
        }
    }
    public TrailsItemData GetSkinData(int index)
    {
        if(index >= Datas.Count) return null;
        return Datas[index];
    }
}
[System.Serializable]
public class TrailsItemData
{
    public int Id;
    public GameObject Particle;
    public Sprite AnhImage;
    public int Price;
    public string NameTag;
}