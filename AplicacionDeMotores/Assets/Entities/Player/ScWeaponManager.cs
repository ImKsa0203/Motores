using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScWeaponManager : MonoBehaviour
{
    [SerializeField] private ScWeapon[] _weapons;
    public ScEntity scEntity;
    public int weaponSelected = 0;

    private void Awake()
    {
        scEntity = GetComponentInParent<ScEntity>();
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
    }
}
