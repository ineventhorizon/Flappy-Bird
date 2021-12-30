using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;
    public static GameManager Instance => instance ?? (instance = FindObjectOfType<GameManager>());
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void OnEnable()
    {
        Observer.startGame += StartGame;
        Observer.replay += Replay;
        Observer.pauseContinue += PauseOrContinue;
        Observer.gameOverNotification += GameOver;
    }
    void OnDisable()
    {
        Observer.startGame -= StartGame;
        Observer.replay -= Replay;
        Observer.pauseContinue -= PauseOrContinue;
        Observer.gameOverNotification -= GameOver;
    }
    private void GameOver()
    {
        Time.timeScale = 0f;
        Observer.updateScoreBoard?.Invoke();
        Debug.Log("GameOver");
    }

    private void StartGame()
    {
        Time.timeScale = 1f;
    }
    //if True Continue, if False Pause
    private void PauseOrContinue(bool status)
    {
        Time.timeScale = status ? 1f : 0f;
    }
    private void Replay(bool loadStartMenu)
    {
        Time.timeScale = loadStartMenu ? 0f : 1f;
        Observer.resetMedals?.Invoke();
        Observer.resetScore?.Invoke();
        SceneManager.LoadScene(0);
    }

    public bool IsGameRunning()
    {
        return Time.timeScale == 0 ? false : true;
    }
}
