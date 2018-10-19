using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ColorChanger : MonoBehaviour {

    public float hue = 0f;
    public float saturation = 1f;
    public float value = 1f;
    private SpriteRenderer spr;

	// Use this for initialization
	void Start () {
        spr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        hue += 0.0025f;

        if (hue > 1) hue = 0f;

        if (spr != null)
        {
            spr.color = Color.HSVToRGB(hue, saturation, value);
        }
	}
}
