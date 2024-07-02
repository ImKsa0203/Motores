using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private int _damage = 10;
    [Header("Refs")]
    [SerializeField] private Weapon _weapon;

    private void Awake()
    {
        _weapon.setStats(_damage, true);
    }

    private void Start()
    {
        _weapon.StartShoot();
    }
}
