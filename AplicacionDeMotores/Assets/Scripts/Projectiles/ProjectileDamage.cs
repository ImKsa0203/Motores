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
                if (entity.isEnemy != isEnemy)
                {
                    damagable.TakeDamage(damage);
                }
            }
            else
            {
                damagable.TakeDamage(damage);
            } 
        }

        if (_collitionLayerMask == (_collitionLayerMask | (1 << collision.gameObject.layer)))
        {
            Destroy(gameObject);
        }
    }

    protected override void OnDamage()
    {
        Destroy(gameObject);
    }
}
