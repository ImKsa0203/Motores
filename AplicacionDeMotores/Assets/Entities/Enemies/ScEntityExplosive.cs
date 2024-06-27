using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScEntityExplosive : ScEntityEnemy
{
    [SerializeField] private GameObject _explosion;
    [SerializeField] private float _timeToExplode = 1;

    public void Exploding()
    {
        Invoke("Die", _timeToExplode);
    }

    protected override void Die()
    {
        GameObject explosion = Instantiate(_explosion, transform.position, Quaternion.identity);
        explosion.GetComponent<ScExplosion>().damage = damage;
        base.Die();
    }
}