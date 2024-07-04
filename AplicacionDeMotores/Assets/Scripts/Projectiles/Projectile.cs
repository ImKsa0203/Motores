using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IDamageable //TP2 - Lautaro Pistolessi
{
    [Header("Stats")]
    [SerializeField] private float _speed = 10;
    [SerializeField] protected float _timeToDestroy = 10;
    protected int _damage = 0;
    protected bool _isEnemy = false;
    [Header("Refs")]
    [SerializeField] protected LayerMask _layerMask;
    protected Rigidbody2D _rigidbody2D;

    protected virtual void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = transform.right * _speed;
        Invoke("InvokeDestroy", _timeToDestroy);
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

    protected void InvokeDestroy()
    {
        TakeDamage(1);
    }
}
