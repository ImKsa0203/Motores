using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : Projectile
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damagable = collision.GetComponent<IDamageable>();
        if (damagable != null)
        {
            Entity entity = collision.GetComponent<Entity>();
            if (entity)
            {
                if (entity.isEnemy != _isEnemy)
                {
                    damagable.TakeDamage(_damage);
                    DestroyProjectile();
                }
            }
            else
            {
                damagable.TakeDamage(_damage);
                DestroyProjectile();
            }
        }
        if (_collition == (_collition | (1 << collision.gameObject.layer)))
        {
            DestroyProjectile();
        }
    }

    protected override void OnDamage()
    {
        DestroyProjectile();
    }
}
