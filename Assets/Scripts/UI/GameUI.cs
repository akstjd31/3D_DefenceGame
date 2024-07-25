using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    // public Text round, money, life, time, mode;
    // private float totalTime, min, sec;

    // private void Awake()
    // {
    //     totalTime = GameManager.MAINTENANCE_TIME;
    // }

    // private void Update()
    // {
    //     round.text = "Round: " + GameManager.ROUND;
    //     life.text = "Life: " + GameManager.LIFE;
    //     money.text = "Money: " + GameManager.MONEY;

    //     totalTime -= Time.deltaTime;

    //     TimeSetting(totalTime);
    //     time.text = (int)min + ":" + (int)sec;

    //     if (totalTime <= 0f)
    //     {
    //         GameManager.isGameTime = !GameManager.isGameTime;

    //         if (GameManager.isGameTime)
    //         {
    //             totalTime = GameManager.GAME_TIME;
    //             mode.text = "mode: " + "Game";
    //             GameManager.ROUND += 1;
    //         }
    //         else
    //         {

    //         }
    //     }
    // }

    // private void TimeSetting(float time)
    // {
    //     min = time / 60;
    //     sec = time % 60;
    // }
}
