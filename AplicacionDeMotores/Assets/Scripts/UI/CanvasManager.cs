using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;

    public TMP_Text coinText;
    public int currentCoins = 0;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        coinText.text = "COINS: " + currentCoins.ToString();
    }

    public void IncreaseCoins(int Valor)
    {
        currentCoins += Valor;
        coinText.text = "COINS: " + currentCoins.ToString();
    }
}
