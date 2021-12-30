using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance => instance ?? (instance = FindObjectOfType<UIManager>());
    [SerializeField] private GameObject startCanvas;
    [SerializeField] private GameObject inGameCanvas;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject pauseCanvas;
    private static bool loadStartMenu = true;
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
        Observer.gameOver += GameOver;
    }
    void OnDisable()
    {
        Observer.gameOver -= GameOver;
    }
    public void StartGame()
    {
        loadStartMenu = false;
        startCanvas.SetActive(loadStartMenu);
        Observer.startGame?.Invoke();
        InGame(true);
    }

    public void InGame(bool status)
    {
        inGameCanvas.SetActive(status);
    }

    public void Replay()
    {
        gameOverCanvas.SetActive(false);
        InGame(true);
        Observer.replay?.Invoke(false);
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        InGame(false);
        Observer.gameOverNotification?.Invoke();
    }

    public void ReturnStartMenu()
    {
        loadStartMenu = true;
        startCanvas.SetActive(loadStartMenu);
        InGame(false);
        Observer.replay?.Invoke(true);
    }

    public void Pause()
    {
        InGame(false);
        pauseCanvas.SetActive(true);
        Observer.pauseContinue?.Invoke(false);
    }

    public void Continue()
    {
        InGame(true);
        pauseCanvas.SetActive(false);
        Observer.pauseContinue?.Invoke(true);
    }
}
