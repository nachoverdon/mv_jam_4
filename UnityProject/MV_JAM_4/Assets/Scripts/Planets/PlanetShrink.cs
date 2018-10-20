using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlanetOrbit))]
public class PlanetShrink : MonoBehaviour {

    public float shrinkSpeed;
    private PlanetOrbit orbit;

	// Use this for initialization
	void Start () {
        orbit = GetComponent<PlanetOrbit>();
	}
	
	// Update is called once per frame
	void Update () {
        Shrink();
	}

    void Shrink()
    {
        if (orbit.radius > 1)
        {
            orbit.radius -= shrinkSpeed;
        }
    }
}
