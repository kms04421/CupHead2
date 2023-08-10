using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class PlayerData
{
    public string Name;
    public int progress;
    public int slotNum;
    public bool[] weaponExist;
}
public class DataManager : MonoBehaviour
{
    //教臂沛
    public static DataManager dataInstance; 

    public PlayerData playerData = new PlayerData();

    string path;
    string filename = "slot";
    public int nowSlot;
    private void Awake()
    {
        #region 教臂沛贸府
        if (dataInstance == null)
        {
            dataInstance = this;
        }
        else if (dataInstance != this)
        {
            Destroy(dataInstance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        #endregion
        path = Application.persistentDataPath + "/";
    }
    public void SaveData()
    {
        
        string data = JsonUtility.ToJson(playerData);
        File.WriteAllText(path + filename + nowSlot.ToString(), data);
    }


    public void LoadData()
    {
       string data  = File.ReadAllText(path + filename+nowSlot.ToString());
        playerData = JsonUtility.FromJson<PlayerData>(data);
    }
}
