using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class Player : Entity
{
    [Header("Refs")]
    [SerializeField] private Transform _weapon;
    private WeaponManager _weaponManager;
    private Camera _camera;

    public static Player player;

    protected override void Awake()
    {
        base.Awake();
        player = this;
        isEnemy = false;
        _weaponManager = GetComponentInChildren<WeaponManager>();
        _camera = GetComponentInChildren<Camera>();
        for (int i = 0; i < _weaponManager._weapons.Length; i++)
        {
            _weaponManager._weapons[i].setStats(_damage, false);
        }
    }

    private void Update()
    {
        if (_health > 0)
        {
            Vector3 direction = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            _weapon.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));

            if (_weapon.eulerAngles.z > 90 && _weapon.eulerAngles.z < 270)
            {
                _weapon.localScale = new Vector3(1, -1, 1);
            }
            else
            {
                _weapon.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void Die()
    {
        GameManager.lives--;
        _health = _maxHealth;
        // Aca hay que hacer un transform al ultimo checkpoint

        if (GameManager.lives <= 0)
        {
            GameManager.instance.ResetLevel();
        }
    }

    public void Horizontal(InputAction.CallbackContext CallbackContext)
    {
        if (CallbackContext.performed || CallbackContext.canceled)
        {
            direction = Mathf.RoundToInt(CallbackContext.ReadValue<float>());
            LookSprite();
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

    public void Ability(InputAction.CallbackContext CallbackContext)
    {
        if (CallbackContext.performed)
        {
            _weaponManager.Ability();
        }
    }


    //Sistema de checkpoints --> NO FUNCIONAL

    /*
    private void OnTriggerEnter(Collider other)
    {
        Checkpoint checkpoint = other.GetComponent<Checkpoint>();

        if (checkpoint != null)
        {
            GameManager.instance.checkpoint = checkpoint.transform;

            Debug.Log("Checkpoint = " + checkpoint.checkpointNum);
        }
    }

    public void Respawn()
    {
        GameManager.instance.LoadCheckpoint(this);
    }
    */
}
