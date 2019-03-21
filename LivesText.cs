using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesText : MonoBehaviour
{

    public static int livesRemaining = 3;
    private int livesOnPreviousFrame;
    public Text livesText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (livesRemaining != livesOnPreviousFrame)
        {
            livesText.text = "Lives: " + livesRemaining;
        }

        livesOnPreviousFrame = livesRemaining;
    }
}
