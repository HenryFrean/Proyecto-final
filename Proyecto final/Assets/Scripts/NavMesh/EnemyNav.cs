using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNav : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;

    [SerializeField] Transform[] wayPoints;
    Vector3 nextPosition;
    float speed = 2f;
    float changeDistance = 0.5f;
    int nextPositionNumber = 0;


    void Start()
    {
        nextPosition = wayPoints[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, nextPosition) < changeDistance)
        {
            nextPositionNumber++;
            if (nextPositionNumber >= wayPoints.Length) nextPositionNumber = 0;
            nextPosition = wayPoints[nextPositionNumber].position;
        }
    }
}
