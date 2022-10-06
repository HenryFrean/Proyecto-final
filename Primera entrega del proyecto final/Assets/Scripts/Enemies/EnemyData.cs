using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New enemy data", menuName = "Crear enemy data")]
public class EnemyData : ScriptableObject
{
    [Header("CONFIGURACION DE MOVIMIENTO")]

    [Tooltip("LA VELOCIDAD DEL MOVIMIENTO ES DE 1 A 10")]
    [SerializeField]
    [Range(1f, 10f)]
    public float speed = 2f;

    [Header("CONFIGURACION DE ATAQUE")]
    [SerializeField]
    [Range(1f, 20f)]
    public float rangeAttack = 2f;

}
