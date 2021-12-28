using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject startCanvas;
    public void StartGame()
    {
        startCanvas.SetActive(false);
        Observer.startGame?.Invoke();
    }
}
