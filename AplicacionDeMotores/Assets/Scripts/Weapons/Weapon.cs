using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [Header("Stats")]
    private int _damage = 10;
    private bool _isEnemy = true;
    [SerializeField] private float _fireRate = 1;
    [SerializeField] private bool _automatic = true;
    [SerializeField] private float _abilityTime = 5;
    [Header("Refs")]
    [SerializeField] protected GameObject _projectilePrefab;
    [Header("Internal")]
    protected Transform _rotation;
    protected Transform _firePoint;
    private bool _shooting = false;
    public bool canShoot = true;
    private Cooldown _abilityCooldown = new Cooldown();

    protected virtual void Awake()
    {
        _rotation = GetComponentInParent<Transform>();
        _firePoint = GetComponentInChildren<Transform>();
        _abilityCooldown.ResetCooldown();
    }

    public void SetStats(int damage, bool isEnemy)
    {
        _damage = damage;
        _isEnemy = isEnemy;
    }

    protected IEnumerator ShootCoroutine()
    {
        while (_shooting)
        {
            if (canShoot)
            {
                Shoot();
                CanShoot(false);
                if (!_automatic)
                {
                    _shooting = false;
                }
                yield return new WaitForSeconds(_fireRate);
                CanShoot(true);
            }
            else
            {
                yield break;
            }
        }
    }

    public IEnumerator Equip()
    {
        CanShoot(false);
        yield return new WaitForSeconds(_fireRate);
        CanShoot(true);
        yield break;
    }

    public void StartShoot()
    {
        _shooting = true;
        StartCoroutine(ShootCoroutine());
    }

    public void CancelShoot()
    {
        _shooting = false;
    }

    protected virtual void CanShoot(bool action)
    {
        canShoot = action;
    }

    protected virtual void Shoot()
    {
        CreateProjectile(_projectilePrefab, _firePoint.position, _rotation.rotation);
    }

    public void TryAbility()
    {
        if (_abilityCooldown.IsReady)
        {
            Ability();
            _abilityCooldown.StartCooldown(_abilityTime);
        }
    }

    protected abstract void Ability();

    protected GameObject CreateProjectile(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        GameObject projectileInstance = Instantiate(prefab, position, rotation);
        projectileInstance.GetComponent<Projectile>().SetStats(_damage, _isEnemy);
        return projectileInstance;
    }
}