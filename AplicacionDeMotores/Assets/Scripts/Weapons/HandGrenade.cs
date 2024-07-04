using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGrenade : Weapon // TP2 - Tomas Racciatti
{
    private SpriteRenderer _spriteRenderer;

    protected override void Awake()
    {
        base.Awake();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void CanShoot(bool action)
    {
        base.CanShoot(action);
        if (action)
        {
            _spriteRenderer.enabled = true;
        }
        else
        {
            _spriteRenderer.enabled = false;
        }
    }

    protected override void Ability()
    {
        for (int i = -3; i <= 3; i++)
        {
            CreateProjectile(_projectilePrefab, _firePoint.position, _rotation.rotation * Quaternion.Euler(0, 0, 5 * i));
        }
    }
}
