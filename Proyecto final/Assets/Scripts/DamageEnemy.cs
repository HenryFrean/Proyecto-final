using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    [SerializeField]
    [Range(2, 30)]
    private int damagePoints = 50;
    public int DamagePoints { get { return damagePoints; } }
}
