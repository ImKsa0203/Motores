using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGranade : Weapon
{
    protected override void Ability()
    {
        for (int i = -3; i <= 3; i++)
        {
            CreateProjectile(_projectilePrefab, _firePoint.position, _rotation.rotation * Quaternion.Euler(0, 0, 5 * i));
        }
    }
}
