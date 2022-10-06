using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersecutionState : State
{
    private NavMeshController navMeshController;
    private ControllerVision controllerVision;

    protected override void Awake()
    {
        base.Awake();
        navMeshController = GetComponent<NavMeshController>();
        controllerVision = GetComponent<ControllerVision>();
    }
    void Update()
    {
        RaycastHit hit;
        if(!controllerVision.PuedeVerAlJugador(out hit, true))
        {
            statesMachine.ActivarEstado(statesMachine.EstadoAlerta);
            return;
        }
        navMeshController.ActualizarPuntoDestinoNavMeshAgent();
    }
}
