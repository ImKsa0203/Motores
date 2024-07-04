using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Fragmentation : Bullet // TP2 - Nicolas Casanova
{
    [HideInInspector] public Rifle rifle;
    [SerializeField] private GameObject prefab;

    public void Fragment()
    {
        TakeDamage(1);
        for (int i = 0; i < 8; i++)
        {
            GameObject bullet = Instantiate(prefab, transform.position, transform.rotation * Quaternion.Euler(0, 0, 45 * i));
            bullet.GetComponent<Projectile>().SetStats(_damage, _isEnemy);
        }
    }

    public override void TakeDamage(int damage)
    {
        rifle.FragmentationAction -= Fragment;
        base.TakeDamage(damage);
    }
}
