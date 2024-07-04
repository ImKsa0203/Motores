using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;

    [SerializeField] private TMP_Text _livesText;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private TMP_Text _coinText;

    private void Awake()
    {
        instance = this;
    }

    public void SetLivesText(int quantity)
    {
        _livesText.text = "LIVES: " + quantity;
    }

    public void SetHealthBar(int actual, int max)
    {
        _healthBar.value = (float)actual / max;
    }

    public void SetCoinsText(int quantity)
    {
        _coinText.text = "COINS: " + quantity;
    }
}
