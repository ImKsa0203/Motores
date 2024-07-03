using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static int lives = 3;
    public static int itemsPicked = 0;
    public Transform[] checkpoints;
    public int checkpointSave = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    public void SetCheckpoint(Transform point)
    {
        int aaa = Array.IndexOf(checkpoints, point);
        if (aaa != -1 && aaa > checkpointSave)
        {
            checkpointSave = aaa;
        }
    }

    public void LoadCheckpoint()
    {
        if (checkpoints[checkpointSave])
        {
            Player.player.transform.position = checkpoints[checkpointSave].position;
        }
        else
        {
            Debug.LogWarning("Checkpoint is not set.");
        }
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        lives = 3;
        itemsPicked = 0;
    }
}
