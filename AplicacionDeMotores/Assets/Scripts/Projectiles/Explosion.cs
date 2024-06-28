using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [Header("AutoDef")]
    public int damage = 10;

    private void Awake()
    {
        Destroy(gameObject, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Entity entity = collision.GetComponent<Entity>();
        if (entity)
        {
            entity.TakeDamage(damage);
        }
    }
}
