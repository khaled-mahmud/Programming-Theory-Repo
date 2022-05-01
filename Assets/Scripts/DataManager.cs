using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; } // Encapsulation (private setters)
    public string playerName { get; set; }
    public int score { get; set; }
    public string currentPlayerName { get; set; }


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadPlayerData();
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int score;
    }

    // Abstraction
    public void SavePlayerData()
    {
        SaveData data = new SaveData();
        data.playerName = this.playerName;
        data.score = this.score;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    // Abstraction
    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            this.score = data.score;
        }
    }
}
