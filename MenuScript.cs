using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    public Button play;
    public Button exit;
	
	// Update is called once per frame
	void Update ()
    {
        play.onClick.AddListener(StartGame);
        exit.onClick.AddListener(ExitGame);
	}

    private void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
