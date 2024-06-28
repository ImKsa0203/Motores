using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRifle : Weapon
{
    protected override void Ability()
    {
        for (int i = -2; i <= 2; i++)
        {
            CreateProjectile(_projectilePrefab, _firePoint.position + i * _rotation.up - 2 * _rotation.right, _rotation.rotation);
        }
    }
}
