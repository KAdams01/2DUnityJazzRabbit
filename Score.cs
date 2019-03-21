using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public static int score;
    private int previousFrameScore;
    private Text scoreText;

	// Use this for initialization
	void Start ()
    {
        scoreText = GetComponent<Text>();
        score = 0;
        previousFrameScore = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (score != previousFrameScore)
        {
            scoreText.text = "Score: " + score;
        }

        previousFrameScore = score;
    }
}
