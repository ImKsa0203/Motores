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
        _target = Player.player.transform; // al ser static el player puedo traer el transform de esta forma
        isEnemy = true;
    }

    protected virtual void Update()
    {
        if (_target && _follow)
        {
            int lastDirection = direction;
            direction = (int)Mathf.Sign(_target.position.x - transform.position.x);
            if (lastDirection != direction)
            {
                LookSprite();
            }
        }
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }

    protected abstract void StartAttack();
    protected abstract void CancelAttack();
}