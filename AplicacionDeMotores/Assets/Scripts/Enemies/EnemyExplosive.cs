using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosive : Enemy
{
    [Header("Stats")]
    [SerializeField] private float _timeToExplode = 1;
    [Header("Refs")]
    [SerializeField] private GameObject _explosion;

    public void Exploding()
    {
        Invoke("Die", _timeToExplode);
    }

    protected override void Die()
    {
        GameObject explosion = Instantiate(_explosion, transform.position, Quaternion.identity);
        explosion.GetComponent<Explosion>().damage = damage;
        base.Die();
    }
}