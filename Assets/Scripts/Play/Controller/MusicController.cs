using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    public AudioSource audioSource;

    public float maxVolume;
    private float soundVolume;

    private bool soundToggle = true;

    public static MusicController Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
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

    public void ChangeMusic(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
