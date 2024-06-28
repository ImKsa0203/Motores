using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileGranade : ProjectileExplosive
{
    [Header("Stats")]
    [SerializeField] private float _inicialTorque = -5;
    [SerializeField] private float _timeToExplode = 1;
    private bool _exploding = false;

    private void Start()
    {
        _rigidbody2D.AddTorque(_inicialTorque);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (_collitionLayerMask == (_collitionLayerMask | (1 << collision.gameObject.layer)) && !_exploding)
        {
            Invoke("Explode", _timeToExplode);
            _exploding = true;
        }
    }
}
