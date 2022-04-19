using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText=null;

    private int score=0;
    private float scoreCountTimerThreshold = 1.0f;
    private float scoreCountTimer;

    public bool CanCountScore { get; set; }
    private StringBuilder scoreStringBuilder=new StringBuilder();

    public static GameManager Instance { get; set; }

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
        CanCountScore = false;
        scoreCountTimer = Time.time + scoreCountTimerThreshold;
    }

    private void OnEnable()
    {
        GameEvents.GameOverEvent+=OnGameOver;
        GameEvents.GameStartEvent+=OnGameStart;
    }
    private void OnDisable()
    {
        GameEvents.GameOverEvent-=OnGameOver;
        GameEvents.GameStartEvent-=OnGameStart;
    }

    private void OnGameStart()
    {
        CanCountScore = true;
    }

    private void OnGameOver()
    {
        CanCountScore = false;
        DataSaver.SaveCurrentScoreData(score);
        DataSaver.SaveHighestScoreData(score);
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

    public void StartGame()
    {
        GameEvents.CallGameStartEvent();
    }
}// Class

