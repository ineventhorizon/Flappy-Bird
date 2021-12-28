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
        Observer.gameOverNotification += GameOver;
    }
    void OnDisable()
    {
        Observer.startGame -= StartGame;
        Observer.replay -= Replay;
        Observer.gameOverNotification -= GameOver;
    }
    private void GameOver()
    {
        Time.timeScale = 0f;
        Observer.resetScore?.Invoke();
        Debug.Log("GameOver");
    }

    private void StartGame()
    {
        Time.timeScale = 1f;
        Observer.startGame -= StartGame;
    }
    private void Pause()
    {

    }
    private void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
