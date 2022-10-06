using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStalker : Enemy
{
    [SerializeField] Transform playerTransform; 

    protected override void MoveForward()
    {
        LookPlayer();
        Vector3 direction = (playerTransform.position - transform.position);
        if (direction.magnitude > 0f)
        {
            transform.position += direction.normalized * enemyData.speed * Time.deltaTime;
        }
    }
    private void LookPlayer()
    {
        Quaternion newRotation = Quaternion.LookRotation(playerTransform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 1.5f * Time.deltaTime);
    }
}
