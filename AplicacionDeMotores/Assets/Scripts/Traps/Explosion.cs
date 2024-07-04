using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour // TP2 - Tomas Racciatti
{
    [HideInInspector]
    public int damage = 10;

    private void Awake()
    {
        Destroy(gameObject, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damagable = collision.GetComponent<IDamageable>();
        if (damagable != null)
        {
            damagable.TakeDamage(damage);
        }
    }
}
