using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScTriggerDelegate : MonoBehaviour
{
    [SerializeField] private UnityEvent EnterEvents;
    [SerializeField] private UnityEvent ExitEvents;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnterEvents.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ExitEvents.Invoke();
    }
}
