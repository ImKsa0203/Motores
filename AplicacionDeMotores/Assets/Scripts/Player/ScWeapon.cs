using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScWeapon : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float _fireRate = 1;
    [SerializeField] protected bool _automatic = true;
    [Header("Refs")]
    [SerializeField] protected GameObject _projectilePrefab;
    private ScWeaponManager _weaponManager;
    private ScCooldown _cooldown = new ScCooldown();

    private void Awake()
    {
        _weaponManager = GetComponentInParent<ScWeaponManager>();
    }

    public void TryShoot()
    {
        if (_cooldown.IsReady)
        {
            Shoot();
            _cooldown.StartCooldown(_fireRate);
            if (_automatic)
            {
                //Invoke("TryShoot", fireRate);
            }
        }
    }

    public void CancelAutomatic()
    {
        CancelInvoke("TryShoot");
    }

    protected virtual void Shoot()
    {
        GameObject projectile = CreateProjectile();
    }

    protected GameObject CreateProjectile()
    {
        GameObject projectile = Instantiate(_projectilePrefab, _weaponManager.transform.position, _weaponManager.transform.rotation);
        ScProjectile scProjectile = projectile.GetComponent<ScProjectile>();
        scProjectile.isEnemy = _weaponManager.scEntity.isEnemy;
        scProjectile.damage = _weaponManager.scEntity.damage;
        return projectile;
    }
}
