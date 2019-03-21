using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    private AudioSource source;
    public AudioClip jumping;
    public AudioClip shooting;
    public AudioClip explosion;
    public AudioClip death;
    public AudioClip backgroundMusic;
    public AudioClip victoryMusic;
    public static SoundManager Instance = null;

    // Initialize the singleton instance.
    private void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        source = GetComponent<AudioSource>();
        restartBackgroundMusic();
    }

    public void restartBackgroundMusic()
    {
        source.clip = backgroundMusic;
        source.Play();
    }

    public void PlayJumpingSound()
    {
        source.PlayOneShot(jumping);
    }

    public void PlayShootingSound()
    {
        source.PlayOneShot(shooting);
    }

    public void PlayExplosionSound()
    {
        source.PlayOneShot(explosion);
    }

    public void playDeathSound()
    {
        source.PlayOneShot(death);
    }

    public void stopAllSounds()
    {
        source.Stop();
    }

    public void playVictorySound()
    {
        Debug.Log("Victory Sound");
        source.PlayOneShot(victoryMusic);
    }
}
