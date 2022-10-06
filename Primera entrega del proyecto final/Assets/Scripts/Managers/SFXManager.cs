using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] sfxCollection;

    private AudioSource sfxSource = null;

    private void Awake()
    {
        sfxSource = GetComponent<AudioSource>();
    }
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
