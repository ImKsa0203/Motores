using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [Header("Weapon")]
    [SerializeField] public Weapon[] _weapons;
    [SerializeField] public int weaponSelected = 0;

    private void Start()
    {
        ChangeWeaponSelected(weaponSelected);
    }

    public void Attack()
    {
        _weapons[weaponSelected].StartShoot();
    }
    public void Cancel()
    {
        _weapons[weaponSelected].CancelShoot();
    }

    public void Ability()
    {
        _weapons[weaponSelected].TryAbility();
    }

    public void ChangeWeaponSelected(int Selected)
    {
        _weapons[weaponSelected].CancelShoot();
        weaponSelected = Selected;
        for (int i = 0; i < _weapons.Length; i++) // Se que no es necesario hacer un for (con un if ya esta listo), pero lo hago escalable para que se puedan poner mas armas
        {
            if (weaponSelected == i)
            {
                _weapons[i].gameObject.SetActive(true);
                _weapons[i].canShoot = true;
            }
            else
            {
                _weapons[i].gameObject.SetActive(false);
            }
        }
    }
}
