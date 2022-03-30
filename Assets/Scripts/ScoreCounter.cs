using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText=null;

    private int score=0;
    private float scoreCountTimerThreshold = 1.0f;
    private float scoreCountTimer;

    public bool CanCountScore { get; set; }
    private StringBuilder scoreStringBuilder=new StringBuilder();

    public static ScoreCounter Instance { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        CanCountScore = true;
        scoreCountTimer = Time.time + scoreCountTimerThreshold;
    }

    private void OnEnable()
    {
        GameEvents.SaveScoreEvent+=OnSaveScoreEvent;
    }

    private void OnDisable()
    {
        GameEvents.GameOverEvent-=OnSaveScoreEvent;
    }

    private void OnSaveScoreEvent()
    {
        CanCountScore = false;
        if (DataSaver.ReadScoreData() < score)
        {
            DataSaver.SaveScoreData(score);
        }
    }

    private void Update()
    {
        if(!CanCountScore)    return;

        if (Time.time > scoreCountTimer)
        {
            scoreCountTimer = Time.time + scoreCountTimerThreshold;
            score+=1000;
            DisplayScore();
        }
    }

    private void DisplayScore()
    {
        scoreStringBuilder.Length = 0;
        scoreStringBuilder.Append(score);

        scoreText.SetText(scoreStringBuilder);
    }

    public int GetScore()
    {
        return score;
    }
}// Class

