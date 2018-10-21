using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchOut : MonoBehaviour {

    public float secondsToDestroy;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, secondsToDestroy);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
