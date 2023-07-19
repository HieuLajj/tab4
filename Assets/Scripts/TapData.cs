using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ScriptableObject", menuName = "TapsData")]
public class TapData : ScriptableObject
{
    public List<TapItemData> Datas = new List<TapItemData>();
    public GameObject GetItem(int index)
    {
        {
            TapItemData itemData = Datas[index];
            return itemData.TapObject;
        }
    }
    public TapItemData GetTapData(int index)
    {
        return Datas[index];

    }
}
[System.Serializable]
public class TapItemData
{
    public int Id;
    public GameObject TapObject;
    public Sprite AnhImage;
    public int Price;
    public Material materialTap;
}