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
    [Header("Refs")]
    [SerializeField] protected GameObject _projectilePrefab;
    protected Transform _rotation;
    protected Transform _firePoint;
    private bool _shooting = false;
    private bool _canShoot = true;

    private void Awake()
    {
        _rotation = GetComponentInParent<Transform>();
        _firePoint = GetComponentInChildren<Transform>();
    }

    protected IEnumerator ShootCoroutine()
    {
        while (_shooting)
        {
            if (_canShoot)
            {
                Shoot();

                if (_automatic)
                {
                    _canShoot = false;
                    yield return new WaitForSeconds(_fireRate);
                    _canShoot = true;
                }
                else
                {
                    yield break;
                }
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

    public void CancelAutomatic()
    {
        _shooting = false;
    }

    protected abstract void Shoot();

    public abstract void Skill();

    protected GameObject CreateProjectile(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        GameObject projectileInstance = Instantiate(prefab, position, rotation);
        Projectile projectile = projectileInstance.GetComponent<Projectile>();
        projectile.damage = damage;
        projectile.isEnemy = isEnemy;
        return projectileInstance;
    }

}
