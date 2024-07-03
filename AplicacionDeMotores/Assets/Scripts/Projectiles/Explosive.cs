using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Explosive : Projectile
{
    [Header("Refs")]
    [SerializeField] private GameObject _explosion;

    public override void TakeDamage(int damage)
    {
        GameObject explosion = Instantiate(_explosion, transform.position, Quaternion.identity);
        explosion.GetComponent<Explosion>().damage = _damage;
        base.TakeDamage(damage);
    }
}
