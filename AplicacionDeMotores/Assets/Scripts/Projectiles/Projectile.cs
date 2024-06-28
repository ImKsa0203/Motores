using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour, IDamageable
{
    [Header("Stats")]
    [SerializeField] public float gravity = 0;
    [SerializeField] public float speed = 10;
    [SerializeField] protected float timeToDestroy = 10;
    [Header("AutoDef")]
    [SerializeField] public int damage = 0;
    [SerializeField] public bool isEnemy = false;
    [Header("Refs")]
    [SerializeField] protected LayerMask _collitionLayerMask;
    protected Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.gravityScale = gravity;
        _rigidbody2D.velocity = transform.right * speed;
        Destroy(gameObject, timeToDestroy);
    }

    public void TakeDamage(int damage)
    {
        OnDamage();
    }

    protected abstract void OnDamage();
}
