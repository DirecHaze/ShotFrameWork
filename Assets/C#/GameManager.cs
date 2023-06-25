using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private GameObject _gameOverCam;
    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private int _botPass;
    private int _botCount;
    private int _score;
    
    [SerializeField]
    private float _startGameTimer = 2;
    [SerializeField]
    private float _mainCountDownTimer;
    [SerializeField]
    private bool _start;


    public override void function()
    {
        base.function();
        Cursor.visible = false;
        _mainCountDownTimer = 60;
    }
    private void FixedUpdate()
    {
        UiManager.Program.timer(_mainCountDownTimer);
        BadGameOver();
        CountDownToStartGame();
        MainGameTimer();

    }
    
   
    //score

    public void PlusScore()
    {
        ScoreCount(50);
    }
    private void ScoreCount(int Score)
    {
        _score += Score;
        UiManager.Program.Score(_score);
    }
    //Bot Check
    public void SpawnBotCount()
    {
        _botCount++;
        UiManager.Program.BotCount(_botCount);
    }
    public void BotDestory()
    {
        _botCount--;
        UiManager.Program.BotCount(_botCount);
    }
    public void BotThatWon()
    {
        _botPass++;
    }
    //Timer
    private void CountDownToStartGame()
    {
        if (_startGameTimer >= 0 )
        {
            _startGameTimer -= 1 * Time.deltaTime;

        }
        else
        {
            _start = true;

           
        }
    }
    private void MainGameTimer()
    {
        if (_start == true)
        {


            _mainCountDownTimer -= 1 * Time.deltaTime;

           

            if (_mainCountDownTimer <= 0)
            {
                _mainCountDownTimer = 0;
                SpawnManager.Program.StopSpawn();
                GoodGameOver();
            }
        }
    }
   //GameOver
    public void BadGameOver()
    {
        
        if(_botPass >= 3)
        {
            _gameOverCam.SetActive(true);
            _player.SetActive(false);
            UiManager.Program.BadGameOver();
            SpawnManager.Program.StopSpawn();
            GameObject[] Bots = GameObject.FindGameObjectsWithTag("Bot");
            foreach (GameObject Bot in Bots)
            {
                GameObject.Destroy(Bot);
            }
            return;
        }
      
    }
    public void GoodGameOver()
    {
        if (_botCount == 0 && _botPass <= 2)
        {
            _gameOverCam.SetActive(true);
            _player.SetActive(false);
            UiManager.Program.GoodGameOver();
            GameObject[] Bots = GameObject.FindGameObjectsWithTag("Bot");
            foreach (GameObject Bot in Bots)
            {
                GameObject.Destroy(Bot);
            }
            return;
        }
    }

}
