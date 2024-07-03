using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour, IDamageable
{
    [Header("Stats")]
    [SerializeField] private float _speed = 10;
    [SerializeField] protected float _timeToDestroy = 10;
    [Header("AutoDef")]
    [SerializeField] protected int _damage = 0;
    [SerializeField] protected bool _isEnemy = false;
    [Header("Refs")]
    [SerializeField] protected LayerMask _collition;
    protected Rigidbody2D _rigidbody2D;

    protected virtual void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = transform.right * _speed;
        Invoke("DestroyProjectile", _timeToDestroy);
    }

    public void SetStats(int dmg, bool enemy)
    {
        _damage = dmg;
        _isEnemy = enemy;
    }

    public virtual void TakeDamage(int damage)
    {
        Destroy(gameObject);
    }
}
