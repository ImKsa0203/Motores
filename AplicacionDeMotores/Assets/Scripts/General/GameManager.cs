using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int lives = 3;
    public int coins = 0;
    public Transform[] checkpoints;
    public int checkpointSave = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Player.player.transform.position = checkpoints[checkpointSave].position;
    }

    public void SetCheckpoint(Transform point)
    {
        int actualPoint = Array.IndexOf(checkpoints, point);
        if (actualPoint != -1 && actualPoint > checkpointSave)
        {
            checkpointSave = actualPoint;
        }
    }

    public void PlayerDie()
    {
        lives--;
        if (lives > 0)
        {
            Player.player.transform.position = checkpoints[checkpointSave].position;
            CanvasManager.instance.SetLivesText(lives);
        }
        else
        {
            ResetLevel();
        }
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddCoins(int Quantity)
    {
        coins += Quantity;
        CanvasManager.instance.SetCoinsText(coins);
    }
}
