using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScExplosion : MonoBehaviour
{
    [Header("AutoDef")]
    public int damage = 10;

    private void Awake()
    {
        Destroy(gameObject, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScEntity entity = collision.GetComponent<ScEntity>();
        if (entity)
        {
            entity.TakeDamage(damage);
        }
    }
}
