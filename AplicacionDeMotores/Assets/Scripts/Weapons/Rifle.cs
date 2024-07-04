using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapon
{
    [HideInInspector] public event System.Action FragmentationAction;

    protected override void Shoot()
    {
        GameObject fragmentationBullet = CreateProjectile(_projectilePrefab, _firePoint.position, _rotation.rotation);
        Fragmentation fragmentationComponent = fragmentationBullet.GetComponent<Fragmentation>();
        FragmentationAction += fragmentationComponent.Fragment;
        fragmentationComponent.rifle = this;
    }

    public override void TryAbility()
    {
        if (FragmentationAction != null)
        {
            base.TryAbility();
        }
    }

    protected override void Ability()
    {
        FragmentationAction.Invoke();
        base.Ability();
    }
}
