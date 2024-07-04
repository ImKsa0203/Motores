using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Misil : Explosive // TP2 - Tomas Racciatti
{
    private void Update()
    {
        transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(_rigidbody2D.velocity.y, _rigidbody2D.velocity.x) * Mathf.Rad2Deg, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collition)
    {
        if (_collition == (_collition | (1 << collition.gameObject.layer)))
        {
            TakeDamage(_damage);
        }
    }
}
