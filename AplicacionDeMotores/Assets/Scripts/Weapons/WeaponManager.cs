using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [Header("Weapon")]
    [SerializeField] private Weapon[] _weapons;
    public int weaponSelected = 0;
    [Header("Refs")]
    public Entity scEntity;

    private void Awake()
    {
        scEntity = GetComponentInParent<Entity>();
    }

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
        _weapons[weaponSelected].CancelAutomatic();
    }

    public void ChangeWeaponSelected(int Selected)
    {
        _weapons[weaponSelected].CancelAutomatic();
        weaponSelected = Selected;
        for (int i = 0; i < _weapons.Length; i++) // Se que no es necesario hacer un for, pero lo hago escalable para que se puedan poner mas armas
        {
            if (weaponSelected == i)
            {
                _weapons[i].gameObject.SetActive(true);
            }
            else
            {
                _weapons[i].gameObject.SetActive(false);
            }
        }
    }
}
