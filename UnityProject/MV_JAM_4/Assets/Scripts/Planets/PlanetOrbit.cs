using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class PlanetOrbit : MonoBehaviour {

    public Transform center;
    public Vector3 axis = Vector3.up;
    public float radius;
    public float radiusSpeed;
    public float translationSpeed;
    public float rotationSpeed;

	// Use this for initialization
	void Start () {
        SetPosition(transform.position);
    }

    // Update is called once per frame
    void Update () {
        RotateAndTranslate();
    }

    void RotateAndTranslate()
    {
        transform.Rotate(new Vector3(0f, 0f, 5f), transform.position.x * rotationSpeed * .9f);
        transform.RotateAround(center.position, axis, translationSpeed * Time.deltaTime);
        Vector3 destination = (transform.position - center.position).normalized * radius + center.position;
        transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * radiusSpeed);
    }

    // Disable trail renderer temporarily so it doesn't show the trail in between positions
    public void SetPosition(Vector3 pos)
    {
        TrailRenderer rend = GetComponent<TrailRenderer>();
        rend.enabled = false;
        transform.position = (pos - center.position).normalized * radius + center.position;
        rend.enabled = true;
    }
}
