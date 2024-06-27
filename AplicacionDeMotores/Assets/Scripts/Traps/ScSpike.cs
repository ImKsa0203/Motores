using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScSpike : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _damageInterval = 0.1f;

    private ScCooldown _cooldown = new ScCooldown();

    void OnTriggerStay2D(Collider2D other)
    {
        ScEntity scEntity = other.GetComponent<ScEntity>();
        if (scEntity != null)
        {
            if (_cooldown.IsReady)
            {
                scEntity.TakeDamage(_damage);
                _cooldown.StartCooldown(_damageInterval);
            }
        }
    }
}
