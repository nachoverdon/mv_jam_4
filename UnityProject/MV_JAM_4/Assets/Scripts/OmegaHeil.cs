using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmegaHeil : MonoBehaviour {

    private Vector3[] positions;
    private int iter = 0;

    void Start()
    {
        positions = new Vector3[transform.childCount];

        foreach (Transform child in transform)
        {
            positions[iter] = child.position;
            iter++;
        }

        iter = 0;

    }

	
	// Update is called once per frame
	void Update () {
        foreach (Transform child in transform)
        {
            if (child.position != transform.GetChild(0).position)
            {
                return;
            }
        }

        iter = 0;

        foreach (Transform child in transform)
        {
            child.position = positions[iter];
            iter++;
        }

        iter = 0;

    }
}
