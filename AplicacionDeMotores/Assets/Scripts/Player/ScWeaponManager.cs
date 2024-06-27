using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScWeaponManager : MonoBehaviour
{
    [Header("Weapon")]
    [SerializeField] private ScWeapon[] _weapons;
    public int weaponSelected = 0;
    [Header("Refs")]
    public ScEntity scEntity;

    private void Awake()
    {
        scEntity = GetComponentInParent<ScEntity>();
    }

    private void Start()
    {
        ChangeWeaponSelected(weaponSelected);
    }

    public void Attack()
    {
        _weapons[weaponSelected].TryShoot();
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
