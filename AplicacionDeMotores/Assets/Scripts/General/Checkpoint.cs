using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int checkpointNum;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() == Player.player)
        {
            // L�gica cuando la colisi�n es con el jugador
            print("a");
        }
    }
}
