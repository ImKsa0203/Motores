using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour // TP2 - Nicolas Casanova
{
    public static GameManager instance;

    private int _lives = 3;
    private int _coins = 0;
    [SerializeField] private Transform[] _checkpoints;
    private int _checkpointSave = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Player.player.transform.position = _checkpoints[_checkpointSave].position;
        CanvasManager.instance.SetCoinsText(_coins);
        CanvasManager.instance.SetHealthBar(100,100);
        CanvasManager.instance.SetLivesText(_lives);
    }

    public void SetCheckpoint(Transform point)
    {
        int actualPoint = Array.IndexOf(_checkpoints, point);
        if (actualPoint != -1 && actualPoint > _checkpointSave)
        {
            _checkpointSave = actualPoint;
        }
    }

    public void PlayerDie()
    {
        _lives--;
        if (_lives > 0)
        {
            Player.player.transform.position = _checkpoints[_checkpointSave].position;
            CanvasManager.instance.SetLivesText(_lives);
        }
        else
        {
            SceneManager.LoadScene("Lose");
        }
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddCoins(int Quantity)
    {
        _coins += Quantity;
        CanvasManager.instance.SetCoinsText(_coins);
        if (_coins >= 10)
        {
            SceneChanger();
        }
    }

    public void SceneChanger()
    {
        int CurrentScene = SceneManager.GetActiveScene().buildIndex;
        if (CurrentScene + 1 < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(CurrentScene + 1);
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
