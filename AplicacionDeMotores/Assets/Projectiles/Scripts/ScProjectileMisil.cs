using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScProjectileMisil : ScProjectile
{
    [SerializeField] private GameObject _explosion;

    private void Update()
    {
        transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(_rigidbody2D.velocity.y, _rigidbody2D.velocity.x) * Mathf.Rad2Deg, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collitionLayerMask == (collitionLayerMask | (1 << collision.gameObject.layer)))
        {
            GameObject explosion = Instantiate(_explosion, transform.position, Quaternion.identity);
            explosion.GetComponent<ScExplosion>().damage = damage;
            Destroy(gameObject);
        }
    }
}
