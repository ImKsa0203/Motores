using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : Projectile
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Entity entity = collision.GetComponent<Entity>();
        if (entity)
        {
            if (entity.isEnemy != isEnemy)
            {
                entity.TakeDamage(damage);
            }
        }
        if (_collitionLayerMask == (_collitionLayerMask | (1 << collision.gameObject.layer)))
        {
            Destroy(gameObject);
        }
    }
}
