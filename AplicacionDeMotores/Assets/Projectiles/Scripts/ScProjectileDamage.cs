using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScProjectileDamage : ScProjectile
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScEntity entity = collision.GetComponent<ScEntity>();
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
