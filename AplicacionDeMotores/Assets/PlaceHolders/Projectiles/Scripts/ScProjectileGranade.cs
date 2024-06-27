using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScProjectileGranade : ScProjectile
{
    [Header("Stats")]
    [SerializeField] private float _inicialTorque = -5;
    [SerializeField] private float _timeToExplode = 1;
    [Header("Refs")]
    [SerializeField] private GameObject _explosion;
    private bool _exploding = false;

    private void Start()
    {
        _rigidbody2D.AddTorque(_inicialTorque);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (_collitionLayerMask == (_collitionLayerMask | (1 << collision.gameObject.layer)) && !_exploding)
        {
            Invoke("Explode", _timeToExplode);
            _exploding = true;
        }
    }

    private void Explode()
    {
        GameObject explosion = Instantiate(_explosion, transform.position, Quaternion.identity);
        explosion.GetComponent<ScExplosion>().damage = damage;
        Destroy(gameObject);
    }
}
