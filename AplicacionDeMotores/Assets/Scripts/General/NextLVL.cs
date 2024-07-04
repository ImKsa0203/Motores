using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLVL : MonoBehaviour
{
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

