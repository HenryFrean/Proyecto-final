using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyPatrol : State
{
    public Transform[] WayPoints;

    private ControllerVision controllerVision;

    private NavMeshController navMeshController;

    private int siguienteWayPoint;

    protected override void Awake()
    {
        base.Awake();
        navMeshController = GetComponent<NavMeshController>();
        controllerVision = GetComponent<ControllerVision>();
    }
   

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(controllerVision.PuedeVerAlJugador(out hit))
        {
            navMeshController.perseguirObjetivo = hit.transform;
            statesMachine.ActivarEstado(statesMachine.EstadoPersecucion);
            return;
        }

        if(navMeshController.HemosLlegado())
        {
            siguienteWayPoint = (siguienteWayPoint + 1) % WayPoints.Length;
            ActualizarWayPointDestino();
        }
    }
    private void OnEnable()
    {
        ActualizarWayPointDestino();
    }

    void ActualizarWayPointDestino()
    {
        navMeshController.ActualizarPuntoDestinoNavMeshAgent(WayPoints[siguienteWayPoint].position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PLAYER") && enabled)
        {
            statesMachine.ActivarEstado(statesMachine.EstadoAlerta);
        }
    }
}
