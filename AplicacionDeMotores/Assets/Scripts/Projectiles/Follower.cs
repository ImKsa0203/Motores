using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : Bullet //TP2 - Lautaro Pistolessi
{
    [Header("Stats")]
    [SerializeField] private float _angularSpeed = 2;
    private Transform _target;

    protected override void Awake()
    {
        base.Awake();
        _target = Player.player.transform;
    }

    private void Update()
    {
        if (_target != null)
        {
            _rigidbody2D.rotation = Mathf.LerpAngle(_rigidbody2D.rotation, Mathf.Atan2(_target.position.y - transform.position.y, _target.position.x - transform.position.x) * Mathf.Rad2Deg, _angularSpeed * Time.deltaTime * (Vector3.Distance(_target.position, transform.position)));
            _rigidbody2D.velocity = _rigidbody2D.velocity.magnitude * transform.right;
        }
    }
}
