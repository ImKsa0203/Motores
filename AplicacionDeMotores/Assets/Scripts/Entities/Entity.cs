using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public abstract class Entity : MonoBehaviour, IDamageable
{
    [Header("Stats")]
    [SerializeField] protected int _health = 100;
    [SerializeField] private float _speed = 3;
    [SerializeField] public int damage = 25;
    [SerializeField] private int _jumps = 1;
    [Header("Refs")]
    [SerializeField] protected SpriteRenderer _spriteRenderer;
    [Header("Internal")]
    public bool isEnemy = false;
    private int _jumpLeft;
    private bool _landed;
    protected int direction = 0;
    private Rigidbody2D _rigidbody2D;

    protected virtual void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _jumpLeft = _jumps;
    }

    protected virtual void FixedUpdate()
    {
        if (_health > 0)
        {
            if (direction != 0)
            {
                if (Mathf.Abs(_rigidbody2D.velocity.x) < _speed)
                {
                    _rigidbody2D.AddForce(new Vector2(direction * _speed * 100 * Time.fixedDeltaTime, 0));
                }
            }
            else
            {
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x * 0.95f, _rigidbody2D.velocity.y);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Die();
        }
    }

    public void Heal(int healing)
    {
        _health += healing;
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    protected void Jump()
    {
        if (_jumpLeft > 0)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
            _rigidbody2D.AddForce(new Vector2(0, 450));
            if (!_landed)
            {
                _jumpLeft--;
            }
        }
    }

    public void Landed(bool value)
    {
        if (_landed = value) //quiero asignarla a la vez, no comparar si es igual
        {
            _jumpLeft = _jumps;
        }
        else
        {
            _jumpLeft--;
        }
    }
}
