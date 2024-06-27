using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScCooldown
{
    private float _nextTime = 0;
    public bool IsReady => Time.time >= _nextTime;
    public void StartCooldown(float cooldownTime) => _nextTime = Time.time + cooldownTime;
    public void ResetCooldown() => _nextTime = Time.time;
    public void DecreaseCooldown(float decreaseTime) => _nextTime -= decreaseTime;
    public float GetCooldown() => _nextTime - Time.time;
}