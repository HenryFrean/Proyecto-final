using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatesMachine : MonoBehaviour
{
    public State EstadoPatrulla;
    public State EstadoAlerta;
    public State EstadoPersecucion;
    public State EstadoInicial;

    public MeshRenderer MeshRendererIndicador;

    private State estadoActual;

    void Start()
    {
        ActivarEstado(EstadoInicial);
    }

    public void ActivarEstado(State nuevoEstado)
    {
        if(estadoActual!=null)estadoActual.enabled = false;
        estadoActual = nuevoEstado;
        estadoActual.enabled = true;

        MeshRendererIndicador.material.color = estadoActual.ColorEstado;
    }
}
