using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int lives = 3;
    public int itemsPicked = 0;
    public Transform[] checkpoints;
    public int checkpointSave = 0;

    private void Awake()
    {
        instance = this;
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
        }
        else
        {
            GameManager.instance.ResetLevel();
        }
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
