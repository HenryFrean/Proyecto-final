using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene2 : MonoBehaviour
{
    [SerializeField]
    [Range(2, 10)]
    private float cooldown;

    private float timeInTrigger = 2;

    private void OnTriggerEnter(Collider other)
    {
        timeInTrigger = 2;
    }

    private void OnTriggerStay(Collider other)
    {
        timeInTrigger += Time.deltaTime;
        if (timeInTrigger >= cooldown)
        {
            SceneManager.LoadScene(2);
        }
    }
}
