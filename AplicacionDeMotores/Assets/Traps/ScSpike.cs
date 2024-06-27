using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScSpike : MonoBehaviour
{
    public int damage = 1;
    public float damageInterval = 0.1f;
    private float nextDamageTime = 0;

    void OnTriggerStay2D(Collider2D other)
    {
        ScEntity scEntity = other.GetComponent<ScEntity>();
        if (scEntity != null)
        {
            if (Time.time >= nextDamageTime)
            {
                scEntity.TakeDamage(damage);
                nextDamageTime = Time.time + damageInterval;
            }
        }
    }
}
