using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ScCanon : MonoBehaviour
{
    [SerializeField] private float _fireRate = 3;
    [SerializeField] private Transform _weapon;
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private int damage = 10;

    private void Start()
    {
        Invoke("Shoot", _fireRate);
    }

    private void Shoot()
    {
        GameObject projectile = Instantiate(_projectilePrefab, _weapon.position, _weapon.rotation);
        ScProjectile scProjectile = projectile.GetComponent<ScProjectile>();
        scProjectile.isEnemy = true;
        scProjectile.damage = damage;
        Invoke("Shoot", _fireRate);
    }
}
