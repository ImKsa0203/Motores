using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Entity
{
    protected Transform _target;
    protected bool _follow = true;



    protected override void Awake()
    {
        base.Awake();
        //_target = FindAnyObjectByType<Player>().transform; // Mal
        _target = Player.player.transform;
        isEnemy = true;
    }

    protected virtual void Update()
    {
        if (_target && _follow)
        {
            direction = (int)Mathf.Sign(_target.position.x - transform.position.x);
            switch (direction)
            {
                case -1:
                    _spriteRenderer.flipX = false;
                    break;
                case 1:
                    _spriteRenderer.flipX = true;
                    break;
            }
        }
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }

    public abstract void StartAttack();
    public abstract void CancelAttack();
}