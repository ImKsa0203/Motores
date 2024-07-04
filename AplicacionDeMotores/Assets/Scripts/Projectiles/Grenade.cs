using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Grenade : Explosive
{
    [Header("Stats")]
    [SerializeField] private float _initialTorque = -5;
    [SerializeField] private float _timeToExplode = 1;
    private bool _exploding = false;
    private void Start()
    {
        _rigidbody2D.AddTorque(_initialTorque);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_collition == (_collition | (1 << collision.gameObject.layer)) && !_exploding)
        {
            Invoke("InvokeDestroy", _timeToExplode);
            _exploding = true;
        }
    }
}