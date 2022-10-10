using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button3D : MonoBehaviour
{
    public UnityEvent OnTriggerButton3D;

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("PLAYER"))
        {
            OnTriggerButton3D?.Invoke();
        }
    }
}
