using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRifle : Weapon
{
    protected override void Shoot()
    {
        CreateProjectile(_projectilePrefab, _firePoint.position, _rotation.rotation);
    }

    public override void Skill()
    {
        for (int i = -2; i <= 2; i++)
        {
            CreateProjectile(_projectilePrefab, _firePoint.position + i * _rotation.up - 2 * _rotation.right, _rotation.rotation);
        }
    }
}
