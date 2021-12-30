using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Observer
{
    public static UnityAction gameOver;
    public static UnityAction gameOverNotification;
    public static UnityAction startGame;
    public static UnityAction<bool> pauseContinue;
    public static UnityAction<bool> replay;
    public static UnityAction<int> updateScore;
    public static UnityAction updateScoreBoard;
    public static UnityAction resetScore;
    public static UnityAction resetMedals;
}
