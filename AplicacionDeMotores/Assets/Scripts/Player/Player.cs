using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class Player : Entity
{
    [Header("Refs")]
    [SerializeField] private WeaponManager _weaponManager;
    [SerializeField] private Transform _weapon;
    [SerializeField] private Camera _camera;

    protected override void Awake()
    {
        base.Awake();
        isEnemy = false;
    }

    private void Update()
    {
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        _weapon.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));

        if (_weapon.eulerAngles.z > 90 && _weapon.eulerAngles.z < 270 )
        {
            _weapon.localScale = new Vector3(1, -1, 1);
        }
        else
        {
            _weapon.localScale = new Vector3(1, 1, 1);
        }
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void Die()
    {
        //pantalla muerte
    }

    public void Horizontal(InputAction.CallbackContext CallbackContext)
    {
        if (CallbackContext.performed || CallbackContext.canceled)
        {
            direction = Mathf.RoundToInt(CallbackContext.ReadValue<float>());
            switch (direction)
            {
                case -1:
                    _spriteRenderer.flipX = false;
                    break;
                case 1:
                    _spriteRenderer.flipX = true;
                    break;
            }
        }
    }

    public void Jump(InputAction.CallbackContext CallbackContext)
    {
        if (CallbackContext.performed)
        {
            Jump();
        }
    }

    public void Attack(InputAction.CallbackContext CallbackContext)
    {
        if (CallbackContext.performed)
        {
            _weaponManager.Attack();
        }
        if (CallbackContext.canceled)
        {
            _weaponManager.Cancel();
        }
    }
}
