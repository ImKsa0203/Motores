using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Coins : MonoBehaviour
{
    public int value;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() == Player.player)
        {
            CanvasManager.Instance.IncreaseCoins(value);
            Destroy(gameObject);
            print("a");
        }
    }
}
