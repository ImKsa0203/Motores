using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public abstract class Entity : MonoBehaviour, IDamageable
{
    [Header("Stats")]
    [SerializeField] protected int _maxHealth = 100;
    [SerializeField] protected int _health;
    [SerializeField] private float _speed = 3;
    [SerializeField] protected int _damage = 10;
    [SerializeField] private int _jumps = 1;
    [SerializeField] public bool isEnemy = false;
    [SerializeField] public Stats stats = new Stats();
    protected SpriteRenderer _spriteRenderer;
    private int _jumpLeft;
    private bool _landed;
    protected int direction = 0;
    private Rigidbody2D _rigidbody2D;

    protected virtual void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _health = _maxHealth;
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

    public virtual void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Die();
        }
    }

    public virtual void Heal(int healing)
    {
        _health += Mathf.Clamp(healing, 0, _maxHealth - _health);
    }

    protected abstract void Die();

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

    protected void LookSprite() // para que lado ve el sprite
    {
        switch (direction)
        {
            case -1:
                _spriteRenderer.flipX = true;
                break;
            case 1:
                _spriteRenderer.flipX = false;
                break;
        }
    }
}
