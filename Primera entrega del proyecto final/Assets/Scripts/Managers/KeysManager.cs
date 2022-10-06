using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysManager : MonoBehaviour
{
    [SerializeField] List<GameObject> keysList;

    private PlayerCollision playerCollision;
    
    public List<GameObject> KeysList { get => keysList; set => keysList = value; }

    void Start()
    {
        playerCollision = GetComponent<PlayerCollision>();
    } 

    void Update()
    {
   
    }
}
