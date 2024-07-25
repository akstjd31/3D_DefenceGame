using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    Maintenance, Game, Menu
}

public class GameManager : MonoBehaviour
{
    public static int ROUND = 0;
    public static int LIFE = 20;
    public const int MAX_LIFE = 20;
    public static int MONEY = 10;
    
    public const float MAINTENANCE_TIME = 120f;
    public const float GAME_TIME = 180f;
    private bool isGameTime = false;

    // 정비 시간, 게임 시간 : 2분, 3분?
    // 정비 - 게임 시작 반복

    private GameState curState;
    private GameUI gameUI;
    public Text round, money, life, mode, time;
    private float totalTime;

    public GameState GetGameState()
    {
        return this.curState;
    }

    public void SetGameState(GameState gameState)
    {
        this.curState = gameState;
    }

    private void Awake()
    {
        gameUI = this.GetComponent<GameUI>();
        MaintenanceTime();
    }

    private void Update()
    {
        if (totalTime <= 0f)
        {
            if (isGameTime)
                MaintenanceTime();
            else
                GameTime();
        }
        else
        {
            totalTime -= Time.deltaTime;
        }

        time.text = ((totalTime / 60) < 10 ? "0" : "") + 
        ((int)(totalTime / 60)).ToString() + ":" + 
        ((totalTime % 60) < 10 ? "0" : "") +
        ((int)(totalTime % 60)).ToString();
    }

    private void UpdateUI()
    {
        round.text = "round: " + ROUND;
        money.text = "money: " + MONEY;
        life.text = "life: " + LIFE;
        mode.text = isGameTime ? "Game" : "Maintenance";
    }

    public void MaintenanceTime()
    {
        SetGameState(GameState.Maintenance);
        isGameTime = false;

        ROUND += 1; LIFE = MAX_LIFE; totalTime = MAINTENANCE_TIME;
        UpdateUI();
    }

    public void GameTime()
    {
        SetGameState(GameState.Game);
        isGameTime = true;
        totalTime = GAME_TIME;

        UpdateUI();
    }
}
