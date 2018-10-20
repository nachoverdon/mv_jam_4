using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorUtil : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static Color HSV(float hue, float saturation, float value)
    {
        hue += 0.0025f;

        if (hue > 1) hue = 0f;

        return Color.HSVToRGB(hue, saturation, value);

    }
}
