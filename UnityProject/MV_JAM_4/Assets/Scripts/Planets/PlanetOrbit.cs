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
        TrailRenderer rend = GetComponent<TrailRenderer>();
        rend.enabled = false;
        transform.position = (transform.position - center.position).normalized * radius + center.position;
        rend.enabled = true;
    }

    // 卐

    //        _
    //       / /\
    //      / / /
    //     / / /   _
    //    /_/ /   / /\
    //    \ \ \  / /  \
    //     \ \ \/ / /\ \
    //  _   \ \ \/ /\ \ \
    ///_/\   \_\  /  \ \ \
    //\ \ \  / /  \   \_\/   HEIL HASTRO! o/
    // \ \ \/ / /\ \ 
    //  \ \ \/ /\ \ \
    //   \ \  /  \ \ \
    //    \_\/   / / /
    //          / / /
    //         /_/ /
    //         \_\/
//####_______###############
//####_______###############
//####_______####___________
//####_______####___________
//##########################
//##########################
//___________####_______####
//___________####_______####
//###############_______####
//###############_______####


//░░░░░░░░░░░░░░░▄▀▄░░░░░░░░░░░░░░░
//░░░░░░░░░░░░░▄▀░░░▀▄░░░░░░░░░░░░░
//░░░░░░░░░░░▄▀░░░░▄▀█░░░░░░░░░░░░░
//░░░░░░░░░▄▀░░░░▄▀░▄▀░▄▀▄░░░░░░░░░
//░░░░░░░▄▀░░░░▄▀░▄▀░▄▀░░░▀▄░░░░░░░
//░░░░░░░█▀▄░░░░▀█░▄▀░░░░░░░▀▄░░░░░
//░░░▄▀▄░▀▄░▀▄░░░░▀░░░░▄█▄░░░░▀▄░░░
//░▄▀░░░▀▄░▀▄░▀▄░░░░░▄▀░█░▀▄░░░░▀▄░
//░█▀▄░░░░▀▄░█▀░░░░░░░▀█░▀▄░▀▄░▄▀█░
//░▀▄░▀▄░░░░▀░░░░▄█▄░░░░▀▄░▀▄░█░▄▀░
//░░░▀▄░▀▄░░░░░▄▀░█░▀▄░░░░▀▄░▀█▀░░░
//░░░░░▀▄░▀▄░▄▀░▄▀░█▀░░░░▄▀█░░░░░░░
//░░░░░░░▀▄░█░▄▀░▄▀░░░░▄▀░▄▀░░░░░░░
//░░░░░░░░░▀█▀░▄▀░░░░▄▀░▄▀░░░░░░░░░
//░░░░░░░░░░░░░█▀▄░▄▀░▄▀░░░░░░░░░░░
//░░░░░░░░░░░░░▀▄░█░▄▀░░░░░░░░░░░░░
//░░░░░░░░░░░░░░░▀█▀░░░░░░░░░░░░░░░ 

    // Update is called once per frame
    void Update () {
        // Aikon me cago en tus muertos xDDDDDDDD
        transform.Rotate(new Vector3(0f, 0f, 5f), transform.position.x * rotationSpeed * .9f);
        transform.RotateAround(center.position, axis, translationSpeed * Time.deltaTime);
        Vector3 destination = (transform.position - center.position).normalized * radius + center.position;
        transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * radiusSpeed);
    }
}
