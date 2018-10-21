using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlanetOrbit))]
public class PlanetShrink : MonoBehaviour {

    public float radiusShrinkSpeed;
    public float maxShrinkSpeed;
    public float sizeShrinkSpeed;
    public float minSize;
    private float size;
    private PlanetOrbit orbit;

	// Use this for initialization
	void Start () {
        orbit = GetComponent<PlanetOrbit>();
        size = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (radiusShrinkSpeed >= maxShrinkSpeed)
            radiusShrinkSpeed = maxShrinkSpeed;
        Shrink();
	}

    void Shrink()
    {
        if (orbit.radius > 1)
        {
            orbit.radius -= radiusShrinkSpeed;

            if (transform.localScale.x > minSize)
            {
                size = transform.localScale.x;
                transform.localScale = new Vector3(size - sizeShrinkSpeed, size - sizeShrinkSpeed, 0);
            }
        }


    }
}
