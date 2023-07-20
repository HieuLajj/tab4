using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataPlayer
{
    private const string ALLDATA = "all_data";
    private static AllData allData;
    // Start is called before the first frame update
    static DataPlayer(){
        allData = JsonUtility.FromJson<AllData>(PlayerPrefs.GetString(ALLDATA));

        if(allData == null){
            allData = new AllData{
                itemList = new List<int>(){}
            };
            SaveData();
        }
    }

    private static void SaveData(){
        var data = JsonUtility.ToJson(allData);
        PlayerPrefs.SetString(ALLDATA, data);
    }

    public static bool IdCheckData(int id){
        return allData.IsCheckDataId(id);
    }

    public static void AddCar(int id){
        allData.AddItem(id);
        SaveData();
    }

}

public class AllData{
    public List<int> itemList;
    public bool IsCheckDataId(int id){
        return itemList.Contains(id);
    }

    public void AddItem(int id){
        if(IsCheckDataId(id))return;
        itemList.Add(id);
    }
}