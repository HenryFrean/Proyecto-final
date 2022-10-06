using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] KeysManager keysManager;

    [SerializeField] private Slider hpBar;

    public static event Action OnDead;

    public static event Action OnWin;

    private MovementPlayer playerMove;

    private PlayerData playerData;

    private HUDManager hudmanager;

    public GameObject destroyDoor;

    public float damage = 0;

    public int count = 0;

    public TMP_Text textCount;

    //SOUNDS
    public GameObject agarrarLlaves;

    public GameObject openTheDoor;

    private void Start()
    {
        playerData = GetComponent<PlayerData>();
        playerMove = GetComponent<MovementPlayer>();      
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("ENTRANDO EN COLISION CON " + other.gameObject.name);
            hpBar.value -= damage;
            if (hpBar.value <= 0)
            {
                PlayerCollision.OnDead?.Invoke();
                Debug.Log("GAME OVER");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Keys"))
        {
            other.gameObject.SetActive(false);
            keysManager.KeysList.Add(other.gameObject);
            NewSound(agarrarLlaves, transform.position, 1f);
            count = count + 1;
            textCount.text = "Keys: " + count;


            if (count == 5)
            {
                Debug.Log("se destruyo la puerta");
                NewSound(openTheDoor, transform.position, 1f);
                Destroy(destroyDoor);
            }
        }

        if (other.gameObject.CompareTag("Win"))
        {
            PlayerCollision.OnWin?.Invoke();
            Debug.Log("YOU WIN");
        }
    }
    private void OpenDoor()
    {
         if (count == 5)
         {
             Debug.Log("se destruyo la puerta");
             Destroy(destroyDoor);
         }
    }

    private void NewSound(GameObject prefab, Vector3 position, float duration = 5f)
    {
        Destroy(Instantiate(prefab, position, Quaternion.identity), duration);
    }
}
