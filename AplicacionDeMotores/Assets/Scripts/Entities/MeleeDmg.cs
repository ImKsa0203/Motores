using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDmg : MonoBehaviour
{
    [SerializeField] public int damage = 0;
    [SerializeField] public bool isEnemy = false;
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
    }
}
