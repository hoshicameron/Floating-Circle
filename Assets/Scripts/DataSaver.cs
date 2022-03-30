using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSaver : MonoBehaviour
{

    /// <summary>
    /// Read player best score
    /// </summary>
    /// <returns></returns>
    public static int ReadScoreData()
    {
        var value = -1;
        if (PlayerPrefs.HasKey("BestScore"))
            value = PlayerPrefs.GetInt("BestScore");

        return value;
    }

    /// <summary>
    /// Save current Score To disk
    /// </summary>
    /// <param name="currentScore"></param>
    public static void SaveScoreData(int currentScore)
    {
        PlayerPrefs.SetInt("BestScore",currentScore);
        PlayerPrefs.Save();
    }

    public static void ClearData()
    {
        if(PlayerPrefs.HasKey("BestScore"))
            PlayerPrefs.SetInt("BestScore",-1);

        PlayerPrefs.Save();
    }


}// Class
