using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Explosive : Projectile
{
    [Header("Refs")]
    [SerializeField] private GameObject _explosion;

    protected override void DestroyProjectile()
    {
        GameObject explosion = Instantiate(_explosion, transform.position, Quaternion.identity);
        explosion.GetComponent<Explosion>().damage = _damage;
        base.DestroyProjectile();
    }

    protected override void OnDamage()
    {
        DestroyProjectile();
    }
}
