using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour, IDamageable // TP2 - Matteo Lescano
{
    [Header("Stats")]
    [SerializeField] private int _damage = 100;
    [Header("Refs")]
    [SerializeField] private GameObject _explosion;

    public void TakeDamage(int damage)
    {
        GameObject explosion = Instantiate(_explosion, transform.position, transform.rotation);
        explosion.GetComponent<Explosion>().damage = _damage;
        Destroy(gameObject);
    }
}
