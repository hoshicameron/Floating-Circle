using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    private void Start()
    {
        GetComponent<TextMeshProUGUI>().SetText($"HighScore: {DataSaver.ReadScoreData()}");
    }
}
