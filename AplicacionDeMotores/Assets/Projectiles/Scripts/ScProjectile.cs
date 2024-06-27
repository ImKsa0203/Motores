using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScProjectile : MonoBehaviour
{
    [SerializeField] public float gravity = 0;
    [SerializeField] public float speed = 10;
    [SerializeField] public int damage = 0;
    [SerializeField] public bool isEnemy = false;
    [SerializeField] protected float timeToDestroy = 10;
    [SerializeField] protected LayerMask collitionLayerMask;
    protected Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.gravityScale = gravity;
        _rigidbody2D.velocity = transform.right * speed;
        Destroy(gameObject, timeToDestroy);
    }
}
