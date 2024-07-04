using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damagable = collision.GetComponent<IDamageable>();
        if (damagable != null)
        {
            Entity entity = collision.GetComponent<Entity>();
            if (entity)
            {
                if (entity.stats.IsEnemy != _isEnemy)
                {
                    damagable.TakeDamage(_damage); // A quien golpeo
                    TakeDamage(_damage); // Yo ( proyectil-bullet)
                }
            }
            else
            {
                damagable.TakeDamage(_damage);
                TakeDamage(_damage);
            }
        }
        if (_collition == (_collition | (1 << collision.gameObject.layer)))
        {
            TakeDamage(_damage);
        }
    }
}
