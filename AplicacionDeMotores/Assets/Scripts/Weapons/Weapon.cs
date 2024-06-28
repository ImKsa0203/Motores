using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [Header("Stats")]
    public int damage = 10;
    public bool isEnemy = true;
    [SerializeField] private float _fireRate = 1;
    [SerializeField] protected bool _automatic = true;
    [SerializeField] private float _abilityCooldown = 5;
    [Header("Refs")]
    [SerializeField] protected GameObject _projectilePrefab;
    [Header("Internal")]
    protected Transform _rotation;
    protected Transform _firePoint;
    private bool _shooting = false;
    public bool canShoot = true;
    private Cooldown _cooldown = new Cooldown();

    private void Awake()
    {
        _rotation = GetComponentInParent<Transform>();
        _firePoint = GetComponentInChildren<Transform>();
        _cooldown.ResetCooldown();
    }

    protected IEnumerator ShootCoroutine()
    {
        while (_shooting)
        {
            if (canShoot)
            {
                Shoot();
                canShoot = false;
                yield return new WaitForSeconds(_fireRate);
                canShoot = true;
            }
            else
            {
                yield break;
            }
        }
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

    private void Shoot()
    {
        CreateProjectile(_projectilePrefab, _firePoint.position, _rotation.rotation);
    }

    public void TryAbility()
    {
        if (_cooldown.IsReady)
        {
            Ability();
            _cooldown.StartCooldown(_abilityCooldown);
        }
    }

    protected abstract void Ability();

    protected GameObject CreateProjectile(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        GameObject projectileInstance = Instantiate(prefab, position, rotation);
        Projectile projectile = projectileInstance.GetComponent<Projectile>();
        projectile.damage = damage;
        projectile.isEnemy = isEnemy;
        return projectileInstance;
    }

}
