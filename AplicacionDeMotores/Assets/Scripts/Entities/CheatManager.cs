using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatManager : MonoBehaviour
{
    public static CheatManager cheatManager;

    private delegate void CheatAction();

    private Dictionary<string, CheatAction> _cheats = new Dictionary<string, CheatAction>();

    private void Awake()
    {
        cheatManager = this;
    }

    private void Start()
    {
        _cheats.Add("AddLife", AddLife);
        _cheats.Add("Heal", Heal);
        _cheats.Add("Invincibility", Invincibility);
        _cheats.Add("Win", Win);
    }

    public void TryCheat(string cheatCode)
    {
        if (_cheats.ContainsKey(cheatCode))
        {
            _cheats[cheatCode].Invoke();
        }
    }

    private void AddLife()
    {
        GameManager.instance.PlayerModifyLife(1);
    }

    private void Heal()
    {
        Player.player.Heal(100);
    }

    private void Invincibility()
    {
        Player.player.isInvincible = !Player.player.isInvincible;
    }

    private void Win()
    {
        GameManager.instance.AddCoins(10);
    }
}
