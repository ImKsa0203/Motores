using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : Enemy
{
    [Header("Stats")]
    [SerializeField] private float _fireRate = 2;
    [Header("Refs")]
    [SerializeField] private Transform _weapon;
    [SerializeField] private GameObject _projectilePrefab;
    private Weapon _weapon2;

    private void Start()
    {
        _weapon2.StartShoot();
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
}