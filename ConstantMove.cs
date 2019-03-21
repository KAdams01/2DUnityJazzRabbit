using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ConstantMove : MonoBehaviour
{
    public float speed;
    private Vector3 startingPoint;
    private Vector3 endPoint;
    private bool forwards;
    private float previousFrameX;
    private SpriteRenderer spriteRend;

	// Use this for initialization
	void Start ()
    {
        startingPoint = new Vector3(-6.767f, transform.position.y, 0f);
        endPoint = new Vector3(6.5f, transform.position.y, 0f);
        forwards = true;
        previousFrameX = startingPoint.x;
        spriteRend = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector3.Lerp(startingPoint, endPoint, Mathf.PingPong(Time.time * speed, 1.0f));
        //The command below is used to flip the character on x axis, I have not figured it out where to put it yet
        

    }

    void LateUpdate()
    {
        if (previousFrameX > transform.position.x)
        {
            forwards = false;
        }
        else
        {
            forwards = true;
        }

        if (forwards)
        {
            spriteRend.flipX = false;
        }
        else
        {
            spriteRend.flipX = true;
        }

        previousFrameX = transform.position.x;
    }
}
