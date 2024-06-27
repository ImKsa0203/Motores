using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScEntityShooter : ScEntityEnemy
{
    [SerializeField] private float _fireRate = 2;
    [SerializeField] private Transform _weapon;
    [SerializeField] protected GameObject _projectilePrefab;

    private void Start()
    {
        Invoke("Shoot", _fireRate);
    }

    protected override void Update()
    {
        base.Update();
        Vector3 direction = _target.position - transform.position;
        _weapon.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));

        if (_weapon.eulerAngles.z > 90 && _weapon.eulerAngles.z < 270)
        {
            _weapon.localScale = new Vector3(2, -2, 2);
        }
        else
        {
            _weapon.localScale = new Vector3(2, 2, 2);
        }
    }

    private void Shoot()
    {
        GameObject projectile = Instantiate(_projectilePrefab, _weapon.position, _weapon.rotation);
        ScProjectileTarget scProjectile = projectile.GetComponent<ScProjectileTarget>();
        scProjectile.isEnemy = isEnemy;
        scProjectile.damage = damage;
        scProjectile.target = _target;
        Invoke("Shoot", _fireRate);
    }
}