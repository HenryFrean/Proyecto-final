using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected EnemyData enemyData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
        Attack();
    }
    protected virtual void MoveForward()
    {
        transform.Translate(Vector3.right * enemyData.speed * Time.deltaTime);
    }

    protected virtual void MoveBack()
    {
        transform.Translate(Vector3.left * enemyData.speed * Time.deltaTime);
    }

    public void Attack()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up, transform.TransformDirection(Vector3.right), out hit, enemyData.rangeAttack))
        {
            if(hit.transform.CompareTag("Player"))
            {
                MoveForward();
                Debug.Log("ATACANDO AL PLAYER");
            }
        }
    }
    public void DrawRaycast()
    {
        Gizmos.color = Color.blue;
        Vector3 directionRay = transform.TransformDirection(Vector3.right) * enemyData.rangeAttack;
        Gizmos.DrawRay(transform.position + Vector3.up, directionRay);
    }
    private void OnDrawGizmos()
    {
        DrawRaycast();
    }
}
