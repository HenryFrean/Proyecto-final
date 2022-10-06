using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerVision : MonoBehaviour
{
    public Transform ojos;
    public float rangoVision = 20f;
    public Vector3 offSet = new Vector3(0f, 0.7f, 0f);

    private NavMeshController navMeshController;

    private void Awake()
    {
        navMeshController = GetComponent<NavMeshController>();
    }


    public bool PuedeVerAlJugador(out RaycastHit hit, bool mirarHaciaElJugador = false)
    {
        Vector3 vectorDireccion;
        if(mirarHaciaElJugador)
        {
            vectorDireccion = (navMeshController.perseguirObjetivo.position + offSet) - ojos.position;
        }
        else
        {
            vectorDireccion = ojos.right;
        }
        return Physics.Raycast(ojos.position, vectorDireccion, out hit, rangoVision) && hit.collider.CompareTag("PLAYER");
    }
}
