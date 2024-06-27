using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float _fireRate = 1;
    [SerializeField] protected bool _automatic = true;
    [Header("Refs")]
    [SerializeField] protected GameObject _projectilePrefab;
    [SerializeField] private WeaponManager _weaponManager;
    [Header("Internal")]
    [SerializeField] private bool _shooting = false;

    private void Awake()
    {
        _weaponManager = GetComponentInParent<WeaponManager>();
    }

    public void StartShoot()
    {
        _shooting = true;
        TryShoot();
    }

    public void TryShoot()
    {
        if (_shooting)
        {
            Shoot();
            if (_automatic)
            {
                Invoke("TryShoot", _fireRate);
            }
        }
    }

    public void CancelAutomatic()
    {
        _shooting = false;
    }

    protected virtual void Shoot()
    {
        GameObject projectile = CreateProjectile();
    }

    protected GameObject CreateProjectile()
    {
        GameObject projectileInstance = Instantiate(_projectilePrefab, _weaponManager.transform.position, _weaponManager.transform.rotation);
        Projectile projectile = projectileInstance.GetComponent<Projectile>();
        projectile.isEnemy = _weaponManager.scEntity.isEnemy;
        projectile.damage = _weaponManager.scEntity.damage;
        return projectileInstance;
    }
}
