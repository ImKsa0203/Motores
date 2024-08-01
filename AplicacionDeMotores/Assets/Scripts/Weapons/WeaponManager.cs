using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour // TP2 - Nicolas Casanova
{
    [Header("Weapon")]
    [SerializeField] public Weapon[] weapons;
    [SerializeField] private int _selected = 0;

    public enum Weapons { Rifle, Granade}
    [SerializeField] private Weapons _weapon;

    private void Start()
    {
        ChangeSelected(_selected);
    }

    public void Attack()
    {
        weapons[_selected].StartShoot();
    }
    public void Cancel()
    {
        weapons[_selected].CancelShoot();
    }

    public void Ability()
    {
        weapons[_selected].TryAbility();
    }

    public void ChangeWeapon(Weapons weapon)
    {
        if (_weapon != weapon)
        {

        }
    }

    public void ChangeSelected(int weapon)
    {
        if (_selected != weapon)
        {
            weapons[_selected].CancelShoot();
            _selected = weapon;
            for (int i = 0; i < weapons.Length; i++) // Se que no es necesario hacer un for (con un if ya esta listo), pero lo hago escalable para que se puedan poner mas armas
            {
                if (_selected == i)
                {
                    weapons[i].gameObject.SetActive(true);
                    weapons[i].canShoot = true;
                }
                else
                {
                    weapons[i].gameObject.SetActive(false);
                }
            }
            weapons[_selected].StartCoroutine(weapons[_selected].Equip());
        }
    }
}
