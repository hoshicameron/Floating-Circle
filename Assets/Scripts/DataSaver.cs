using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSaver : MonoBehaviour
{

    /// <summary>
    /// Read player current score
    /// </summary>
    /// <returns></returns>
    public static int ReadCurrentScoreData()
    {
        var value = -1;
        if (PlayerPrefs.HasKey("CurrentScore"))
            value = PlayerPrefs.GetInt("CurrentScore");

        return value;
    }

    /// <summary>
    /// Save current Score To disk
    /// </summary>
    /// <param name="score"></param>
    public static void SaveCurrentScoreData(int score)
    {
        PlayerPrefs.SetInt("CurrentScore",score);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Read player highest score
    /// </summary>
    /// <returns></returns>
    public static int ReadHighestScoreData()
    {
        var value = -1;
        if (PlayerPrefs.HasKey("HighestScore"))
            value = PlayerPrefs.GetInt("HighestScore");

        return value;
    }

    /// <summary>
    /// Save highest Score To disk
    /// </summary>
    /// <param name="score"></param>
    public static void SaveHighestScoreData(int score)
    {
        if (score > ReadHighestScoreData())
        {
            PlayerPrefs.SetInt("HighestScore", score);
            PlayerPrefs.Save();
        }
    }

    public static void ClearData()
    {
        if(PlayerPrefs.HasKey("HighestScore"))
            PlayerPrefs.SetInt("HighestScore",-1);

        PlayerPrefs.Save();
    }

}// Class
