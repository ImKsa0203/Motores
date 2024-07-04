using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Enemy //TP2 - Lautaro Pistolessi
{
    [Header("Refs")]
    [SerializeField] private Transform _weaponTransform;
    [SerializeField] private Weapon _weaponScript;

    protected override void Update()
    {
        base.Update();
        Vector3 direction = _target.position - transform.position;
        _weaponTransform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));

        if (_weaponTransform.eulerAngles.z > 90 && _weaponTransform.eulerAngles.z < 270) //flip arma
        {
            _weaponTransform.localScale = new Vector3(2, -2, 2);
        }
        else
        {
            _weaponTransform.localScale = new Vector3(2, 2, 2);
        }
    }

    protected override void StartAttack()
    {
        _weaponScript.StartShoot();
    }
    protected override void CancelAttack()
    {
        _weaponScript.CancelShoot();
    }
}