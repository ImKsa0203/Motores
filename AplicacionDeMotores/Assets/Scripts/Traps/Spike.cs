using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [Header("Stats")]
    //[SerializeField] private int _damageEnter = 10;
    [SerializeField] private int _damageStay = 1;
    [SerializeField] private float _damageInterval = 0.1f;

    private Cooldown _cooldown = new Cooldown();
    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damagable = other.GetComponent<IDamageable>();
        damagable.TakeDamage(_damageEnter);
    }*/

    void OnTriggerStay2D(Collider2D other)
    {
        IDamageable damagable = other.GetComponent<IDamageable>();
        if (_cooldown.IsReady && damagable != null)
        {
            damagable.TakeDamage(_damageStay);
            _cooldown.StartCooldown(_damageInterval);
        }
    }
}
