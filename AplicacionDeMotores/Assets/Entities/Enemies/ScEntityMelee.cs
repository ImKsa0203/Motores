using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScEntityMelee : ScEntityEnemy
{
    [SerializeField] private float _fireRate = 2;
    [SerializeField] private float _timeAttacking = 0.5f;
    [SerializeField] private GameObject _attackObject;
    private Collider2D _attackCollider;

    protected override void Awake()
    {
        base.Awake();
        _attackCollider = _attackObject.GetComponent<Collider2D>();
        _attackObject.SetActive(false);
    }

    public void Attack()
    {
        _attackObject.SetActive(true);
        Vector3 direction = _target.position - transform.position;
        _attackObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));
        Invoke("DeactivateCollider", _timeAttacking);
        Invoke("Attack", _fireRate);
    }

    private void DeactivateCollider()
    {
        _attackObject.SetActive(false);
    }

    public void CancelAttack()
    {
        CancelInvoke("Attack");
    }
}