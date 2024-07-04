using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Enemy // TP2 - Matteo Lescano
{
    [Header("Stats")]
    [SerializeField] private float _fireRate = 2;
    [SerializeField] private float _timeAttacking = 0.5f;
    [Header("Refs")]
    [SerializeField] private GameObject _attackObject;
    [SerializeField] private MeleeDmg _meleeDmg;

    protected override void Awake()
    {
        base.Awake();
        _attackObject.SetActive(false);
        _meleeDmg.damage = stats.Damage;
        _meleeDmg.isEnemy = stats.IsEnemy;
    }

    protected override void StartAttack()
    {
        _attackObject.SetActive(true);
        Vector3 direction = _target.position - transform.position;
        _attackObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));
        Invoke("DeactivateCollider", _timeAttacking);
        Invoke("StartAttack", _fireRate);
    }

    protected override void CancelAttack()
    {
        CancelInvoke("StartAttack");
    }

    private void DeactivateCollider()
    {
        _attackObject.SetActive(false);
    }
}