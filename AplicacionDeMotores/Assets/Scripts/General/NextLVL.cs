using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLVL : MonoBehaviour //TP2 - Lautaro Pistolessi
{
    public void SceneChanger()
    {
        SceneManager.LoadScene("Level1");
    }
}

