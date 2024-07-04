using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;

    public TMP_Text livesText;
    public TMP_Text coinText;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        livesText.text = "LIVES: " + GameManager.instance.lives;
        coinText.text = "COINS: " + GameManager.instance.coins;
    }

    public void SetLivesText(int quantity)
    {
        livesText.text = "LIVES: " + quantity;
    }

    public void SetCoinsText(int quantity)
    {
        coinText.text = "COINS: " + quantity;
    }
}
