using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;
    public static ScoreManager Instance => instance ?? (instance = FindObjectOfType<ScoreManager>());

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreBoardText;
    public List<Image> medals;
    public List<int> medalPoints;
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
        Observer.updateScoreBoard += UpdateScoreBoard;
        Observer.resetScore += ResetScore;
        Observer.resetMedals += ResetMedals;
    }
    void OnDisable()
    {
        Observer.updateScore -= UpdateScore;
        Observer.updateScoreBoard -= UpdateScoreBoard;
        Observer.resetScore -= ResetScore;
        Observer.resetMedals -= ResetMedals;
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

    private void UpdateScoreBoard()
    {
        for(int i = medals.Count-1; i >= 0; i--)
        {
            if(totalScore >= medalPoints[i])
            {
                medals[i].gameObject.SetActive(true);
                scoreBoardText.SetText(totalScore.ToString());
                return;
            }
        } 
    }
    private void ResetMedals()
    {
        for (int i = 0; i < medals.Count; i++)
        {
            medals[i].gameObject.SetActive(false);
        }
    }


}
