using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public float maxVolume;
    private float soundVolume;
    
    private bool soundToggle = true;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.volume = maxVolume;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) 
            ChangeVolume();
    }

    private void ChangeVolume()
    {
        if (soundToggle) soundVolume = maxVolume;
        else soundVolume = 0f;

        soundToggle = !soundToggle;

        audioSource.volume = soundVolume;
    }
}
