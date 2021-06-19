using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string userName;
    public int HighScore;
    public string HighScoreName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        } else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        LoadHighScore();
    }

    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string highScoreName;
    }

    public void SaveHighScore(int highscore)
    {
        if (isHighScore(highscore))
        {
            this.HighScore = highscore;
            this.HighScoreName = userName;

            SaveData data = new SaveData();
            data.highScore = this.HighScore;
            data.highScoreName = this.HighScoreName;

            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/saveFile.json", json);
        }
    }

    private bool isHighScore(int highscore)
    {
        if (this.HighScore == 0)
        {
            return true;
        } else if (this.HighScore < highscore)
        {
            return true;
        } else
        {
            return false;
        }
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/saveFile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScore = data.highScore;
            HighScoreName = data.highScoreName;
            Debug.Log("File exists and loaded data");
        }
    }

    

}
