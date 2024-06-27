using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScFloorCollider : MonoBehaviour
{
    private ScEntity scEntity;
    private int overlaped = 0;

    private void Awake()
    {
        scEntity = GetComponentInParent<ScEntity>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        overlaped++;
        scEntity.Landed(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        overlaped--;
        if (overlaped == 0)
        {
            scEntity.Landed(false);
        }
    }
}
