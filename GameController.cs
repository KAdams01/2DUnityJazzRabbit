using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Jazz;
    public GameObject enemy;

    public static GameController Instance = null;

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

    // Use this for initialization
    void Start ()
    {
        //SpawnJazz();
        SpawnEnemies();
	}

    private void SpawnEnemies()
    {
        float y = -2.87f;
        for (int i = 0; i < 6; i++)
        {
            Vector2 spawnPosition = new Vector2(-6.767f, y);
            Instantiate(enemy, spawnPosition, transform.rotation);
            y += 0.937f;
        }
    }

    public void respawnAllEnemies()
    {
        GameObject[] findGameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in findGameObjects)
        {
            Destroy(enemy);
        }
        SpawnEnemies();
    }

/*    private void SpawnJazz()
    {
        Vector2 spawnPosition = new Vector2(-7.329f, -3.802f);
        Instantiate(Jazz, spawnPosition, transform.rotation);
    }*/
}
