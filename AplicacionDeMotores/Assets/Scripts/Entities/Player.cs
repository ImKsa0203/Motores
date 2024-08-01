using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : Entity // TP2 - Nicolas Casanova
{
    [Header("Refs")]
    [SerializeField] private Transform _weapon;
    private WeaponManager _weaponManager;
    private Camera _camera;

    public static Player player;
    public bool isInvincible = false;

    /*
    public GameObject cheatConsolePanel;
    public TMP_InputField cheatInputField;
    */
    private PlayerInput playerInput;

    bool showConsole;
    string input;

    protected override void Awake()
    {
        base.Awake();
        player = this;
        _weaponManager = GetComponentInChildren<WeaponManager>();
        _camera = GetComponentInChildren<Camera>();
        playerInput = GetComponent<PlayerInput>();
        for (int i = 0; i < _weaponManager.weapons.Length; i++)
        {
            _weaponManager.weapons[i].SetStats(stats.Damage, false);
        }
    }

    private void Start()
    {
        CanvasManager.instance.SetHealthBar(_health, stats.MaxHealth);
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

    public override void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            base.TakeDamage(damage);
            CanvasManager.instance.SetHealthBar(_health, stats.MaxHealth);
        }
    }

    public override void Heal(int healing)
    {
        base.Heal(healing);
        CanvasManager.instance.SetHealthBar(_health, stats.MaxHealth);
    }

    protected override void Die()
    {
        GameManager.instance.PlayerModifyLife(-1);
        _health = stats.MaxHealth;
        CanvasManager.instance.SetHealthBar(_health, stats.MaxHealth);
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

    public void Restart(InputAction.CallbackContext CallbackContext)
    {
        if (CallbackContext.performed)
        {
            GameManager.instance.ResetLevel();
        }
    }
    /*
    public void ToggleCheatConsole(InputAction.CallbackContext CallbackContext)
    {
        if (CallbackContext.performed)
        {
            bool isActive = cheatConsolePanel.activeSelf;
            cheatConsolePanel.SetActive(!isActive);

            if (!isActive)
            {
                cheatInputField.ActivateInputField();
                cheatInputField.Select();
                playerInput.SwitchCurrentActionMap("UI");
            }
            else
            {
                cheatInputField.DeactivateInputField();
                playerInput.SwitchCurrentActionMap("Default");
            }
        }
    }*/

    public void OnToggleDebug()
    {
        showConsole = !showConsole;
        /*
        if (showConsole)
        {
            playerInput.SwitchCurrentActionMap("UI");
        }
        else
        {
            playerInput.SwitchCurrentActionMap("Default");
        }*/
    }

    private void OnGUI()
    {
        if (!showConsole) { return; }

        float y = 0f;

        GUI.Box(new Rect(0, y, Screen.width, 30), "");
        GUI.backgroundColor = Color.black;
        input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), input);
    }

    public void EnterCheat(InputAction.CallbackContext CallbackContext)
    {
        if (CallbackContext.performed)
        {
            CheatManager.cheatManager.TryCheat(input);
        }
    }
}
