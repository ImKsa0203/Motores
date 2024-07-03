using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [Header("Weapon")]
    [SerializeField] public Weapon[] _weapons;
    [SerializeField] private int selected = 0;

    private void Start()
    {
        ChangeSelected(selected);
    }

    public void Attack()
    {
        _weapons[selected].StartShoot();
    }
    public void Cancel()
    {
        _weapons[selected].CancelShoot();
    }

    public void Ability()
    {
        _weapons[selected].TryAbility();
    }

    public void ChangeSelected(int weapon)
    {
        if (selected != weapon)
        {
            _weapons[selected].CancelShoot();
            selected = weapon;
            for (int i = 0; i < _weapons.Length; i++) // Se que no es necesario hacer un for (con un if ya esta listo), pero lo hago escalable para que se puedan poner mas armas
            {
                if (selected == i)
                {
                    _weapons[i].gameObject.SetActive(true);
                    _weapons[i].canShoot = true;
                }
                else
                {
                    _weapons[i].gameObject.SetActive(false);
                }
            }
            _weapons[selected].StartCoroutine(_weapons[selected].Equip());
        }
    }
}
