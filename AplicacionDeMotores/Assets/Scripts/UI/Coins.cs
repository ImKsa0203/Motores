using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Coins : MonoBehaviour
{
    [SerializeField] private int _quantity = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() == Player.player)
        {
            GameManager.instance.AddCoins(_quantity);
            Destroy(gameObject);
        }
    }
}
