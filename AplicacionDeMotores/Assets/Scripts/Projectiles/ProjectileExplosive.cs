using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileExplosive : Projectile
{
    [Header("Refs")]
    [SerializeField] private GameObject _explosion;

    protected void Explode()
    {
        GameObject explosion = Instantiate(_explosion, transform.position, Quaternion.identity);
        explosion.GetComponent<Explosion>().damage = damage;
        Destroy(gameObject);
    }

    protected override void OnDamage()
    {
        Explode();
    }
}
