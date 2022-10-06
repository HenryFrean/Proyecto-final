using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HUDManager : MonoBehaviour
{
    private static HUDManager instance;
    public static HUDManager Instance { get => instance; }

    [SerializeField] private GameObject gameOverPanel;

    [SerializeField] private GameObject youWinPanel;


    private void Awake()
    {
        Debug.Log("EJECUTANDO AWAKE");
        if (instance == null)
        {
            instance = this;
            Debug.Log(instance);
            PlayerCollision.OnDead += GameOver;
            PlayerCollision.OnWin += Win;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void SetHPBar(int newValue)
    {
     
    }

    private void OnDisable()
    {
        PlayerCollision.OnDead -= GameOver;
        PlayerCollision.OnWin -= Win;
    }

    private void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    private void Win()
    {
        youWinPanel.SetActive(true);
    }
}
