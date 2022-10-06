using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertState : State
{
    public float velocidadGiroBusqueda = 120f;
    public float duracionBusqueda = 1f;
    
    private NavMeshController navMeshController;
    private ControllerVision controllerVision;
    private float tiempoBuscando;

    protected override void Awake()
    {
        base.Awake();
        navMeshController = GetComponent<NavMeshController>();
        controllerVision = GetComponent<ControllerVision>();
    }

    void OnEnable()
    {
        navMeshController.DetenerNavMeshAgent();
        tiempoBuscando = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (controllerVision.PuedeVerAlJugador(out hit))
        {
            navMeshController.perseguirObjetivo = hit.transform;
            statesMachine.ActivarEstado(statesMachine.EstadoPersecucion);
            return;
        }

        transform.Rotate(0f, velocidadGiroBusqueda * Time.deltaTime, 0f);
        tiempoBuscando += Time.deltaTime;
        if(tiempoBuscando >= duracionBusqueda)
        {
            statesMachine.ActivarEstado(statesMachine.EstadoPatrulla);
            return;
        }
    }
}
