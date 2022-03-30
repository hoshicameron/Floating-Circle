using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverPopup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentScoreText=null;
    [SerializeField] private TextMeshProUGUI bestScoreText = null;
    [SerializeField] private GameObject gameOverPopup = null;
    private void OnEnable()
    {
        gameOverPopup.SetActive(false);
        GameEvents.GameOverEvent+=OnGameOverEvent;


    }

    private void OnDisable()
    {
        GameEvents.GameOverEvent-=OnGameOverEvent;
    }

    private void OnGameOverEvent()
    {
        gameOverPopup.SetActive(true);
        currentScoreText.SetText(ScoreCounter.Instance.GetScore().ToString());
        bestScoreText.SetText(DataSaver.ReadScoreData().ToString());
    }
}
