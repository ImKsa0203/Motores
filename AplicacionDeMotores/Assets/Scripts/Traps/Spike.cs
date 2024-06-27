using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _damageInterval = 0.1f;

    private Cooldown _cooldown = new Cooldown();

    void OnTriggerStay2D(Collider2D other)
    {
        Entity scEntity = other.GetComponent<Entity>();
        if (scEntity != null)
        {
            if (_cooldown.IsReady)
            {
                scEntity.TakeDamage(_damage);
                _cooldown.StartCooldown(_damageInterval);
            }
        }
    }
}
