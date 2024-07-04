using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Stats
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private int _jumps;
    [SerializeField] private bool _isEnemy;

    public Stats(int maxHealth, float speed, int damage, int jumps, bool isEnemy)
    {
        _maxHealth = maxHealth;
        _speed = speed;
        _damage = damage;
        _jumps = jumps;
        _isEnemy = isEnemy;
    }

    public int MaxHealth => _maxHealth;
    public float Speed => _speed;
    public int Damage => _damage;
    public int Jumps => _jumps;
    public bool IsEnemy => _isEnemy;
}
