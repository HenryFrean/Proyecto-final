using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public Color ColorEstado;
    protected StatesMachine statesMachine;

    protected virtual void Awake()
    {
        statesMachine = GetComponent<StatesMachine>();
    }
}
