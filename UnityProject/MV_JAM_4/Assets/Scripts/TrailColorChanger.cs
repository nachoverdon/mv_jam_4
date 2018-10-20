using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class TrailColorChanger : MonoBehaviour {

    public float hue = 0f;
    public float saturation = 1f;
    public float value = 1f;
    private TrailRenderer trail;

    // Use this for initialization
    void Start() {
        trail = GetComponent<TrailRenderer>();
        hue = Random.value;
    }

    // Update is called once per frame
    void Update() {
        hue += 0.0025f;

        if (hue > 1) hue = 0f;

        if (trail != null)
        {
            Color startColor = Color.HSVToRGB(hue, saturation, value);
            Color endColor = Color.HSVToRGB(hue, saturation, value);
            Gradient gradient = new Gradient();
            
            gradient.colorKeys = new [] { new GradientColorKey(startColor, 0), new GradientColorKey(endColor, 1) };
            trail.colorGradient = gradient;
        }
    }
}
