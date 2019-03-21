using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    private static bool gameEnded = false;
    private static SoundManager sm;
    public static Text endText;
    private GameController gameController;

	// Use this for initialization
	void Start () {
		sm = SoundManager.Instance;
        gameController = GameController.Instance;
        endText = GameObject.Find("EndOfLevel").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        if (gameEnded && Input.GetKeyDown(KeyCode.Space))
        {
            sm.stopAllSounds();
            ResetGame();
        }
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            TriggerEndGame();
        }
    }

    public static void TriggerEndGame()
    {
        sm.stopAllSounds();
        if (LivesText.livesRemaining > 0)
        {
            sm.playVictorySound();
        }
        Time.timeScale = 0;
        gameEnded = true;
        endText.gameObject.SetActive(true);
        endText.text = "Game Over\nScore: " + Score.score + "\nPress Space to play again" + "\n\nNew levels coming soon!\n\n(Definitely not copyrighted ending music...)";
    }

    void ResetGame()
    {
        gameController.respawnAllEnemies();
        endText.gameObject.SetActive(false);
        sm.restartBackgroundMusic();
        Time.timeScale = 1;
        gameEnded = false;
        LivesText.livesRemaining = 3;
        Score.score = 0;
    }
}
