using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ScCanon : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _fireRate = 3;
    [Header("Refs")]
    [SerializeField] private Transform _weapon;
    [SerializeField] private GameObject _projectilePrefab;

    private void Start()
    {
        Invoke("Shoot", _fireRate);
    }

    private void Shoot()
    {
        GameObject projectile = Instantiate(_projectilePrefab, _weapon.position, _weapon.rotation);
        ScProjectile scProjectile = projectile.GetComponent<ScProjectile>();
        scProjectile.isEnemy = true;
        scProjectile.damage = _damage;
        Invoke("Shoot", _fireRate);
    }
}
