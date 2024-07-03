using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomer : Enemy
{
    [Header("Stats")]
    [SerializeField] private float _timeToExplode = 1;
    [Header("Refs")]
    [SerializeField] private GameObject _explosion;

    protected override void StartAttack()
    {
        Invoke("Die", _timeToExplode);
    }

    protected override void CancelAttack()
    {
        CancelInvoke("Die");
    }

    protected override void Die()
    {
        GameObject explosion = Instantiate(_explosion, transform.position, Quaternion.identity);
        explosion.GetComponent<Explosion>().damage = _damage;
        base.Die();
    }
}