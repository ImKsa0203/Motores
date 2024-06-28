using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Canon : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private int _damage = 10;
    [Header("Refs")]
    [SerializeField] private Transform _weaponTransform;
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Weapon _weapon;

    private void Awake()
    {
        _weapon = GetComponent<Weapon>();
    }

    private void Start()
    {
        _weapon.TryShoot();
    }
}
