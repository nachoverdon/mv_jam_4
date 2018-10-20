using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSize : MonoBehaviour {

    public float initScale;
    public float maxScale;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.localScale.x >= maxScale)
        {
            transform.localScale = new Vector3(initScale, initScale, 0);
        }
	}
}
