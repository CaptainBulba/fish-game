using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    public float maxVolume;
    private float soundVolume;

    private bool soundToggle = true;

    private AudioSource audioSource;

    public AudioClip playMusic;
    public AudioClip gameoverMusic;

    private string playScene = "Play";
    private string gameoverScene = "Gameover";

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

    public void ChangeMusic()
    {
        string levelName = SceneManager.GetActiveScene().name;
        AudioClip music;

        if (levelName == playScene) music = playMusic;
        else music = gameoverMusic;

        audioSource.clip = music;
    }
}
