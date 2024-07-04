using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;

    [SerializeField] private TMP_Text livesText;
    [SerializeField] private Slider healthBar;
    [SerializeField] private TMP_Text coinText;

    private void Awake()
    {
        instance = this;
    }

    public void SetLivesText(int quantity)
    {
        livesText.text = "LIVES: " + quantity;
    }

    public void SetHealthBar(int actual, int max)
    {
        healthBar.value = (float)actual / max;
    }

    public void SetCoinsText(int quantity)
    {
        coinText.text = "COINS: " + quantity;
    }
}
