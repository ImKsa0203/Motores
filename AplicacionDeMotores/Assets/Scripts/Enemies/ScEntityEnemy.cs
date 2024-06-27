using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScEntityEnemy : ScEntity
{
    [Header("Refs")]
    protected Transform _target;
    protected bool _follow = true;

    protected override void Awake()
    {
        base.Awake();
        _target = FindAnyObjectByType<ScEntityPlayer>().transform;
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
}