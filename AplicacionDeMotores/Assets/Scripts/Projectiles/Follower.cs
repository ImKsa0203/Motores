using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : Bullet
{
    [Header("Stats")]
    [SerializeField] private float angularSpeed = 2;
    [Header("AutoDef")]
    public Transform target;

    protected override void Awake()
    {
        base.Awake();
        target = Player.player.transform;
    }

    private void Update()
    {
        if (target != null)
        {
            _rigidbody2D.rotation = Mathf.LerpAngle(_rigidbody2D.rotation, Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg, angularSpeed * Time.deltaTime / (Vector3.Distance(target.position, transform.position) + 1));
            _rigidbody2D.velocity = _rigidbody2D.velocity.magnitude * transform.right;
        }
    }
}
