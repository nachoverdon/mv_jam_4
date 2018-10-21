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
        transform.localScale = new Vector3(transform.localScale.x + 0.0025f, transform.localScale.y + 0.0025f, 0f);
	}
}
