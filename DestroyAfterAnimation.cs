using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class DestroyAfterAnimation : MonoBehaviour
{
    private SoundManager sm;
	// Use this for initialization
	void Start ()
    {
        sm = SoundManager.Instance;
        sm.PlayExplosionSound();
        Destroy(gameObject, 1);
    }
}
