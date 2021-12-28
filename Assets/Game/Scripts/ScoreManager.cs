using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;
    public static ScoreManager Instance => instance ?? (instance = FindObjectOfType<ScoreManager>());
    public TextMeshProUGUI scoreText;
    private static int totalScore = 0;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void OnEnable()
    {
        Observer.updateScore += UpdateScore;
        Observer.resetScore += ResetScore;
    }
    void OnDisable()
    {
        Observer.updateScore -= UpdateScore;
        Observer.resetScore -= ResetScore;
    }
    private void UpdateScore(int score)
    {
        totalScore += score;
        scoreText.SetText(totalScore.ToString());
    }

    private void ResetScore()
    {
        totalScore = 0;
        scoreText.SetText(totalScore.ToString());
    }
}
