using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float leanAngleHorizontal;
    public float leanAngleVertical;
    public float speed = 0.2f;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        CheckMovement();
        
	}

    void CheckMovement()
    {
        float horiRaw = Input.GetAxisRaw("Horizontal");
        float vertRaw = Input.GetAxisRaw("Vertical");
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        //SpriteRenderer spr = GetComponent<SpriteRenderer>();
        //if (horiRaw < 0) spr.flipX = true;
        //else spr.flipX = false;

        // Lean to the sides/up-down depending on direction
        transform.rotation = Quaternion.Euler(new Vector3(-vert * leanAngleVertical, 0f, -hori * leanAngleHorizontal));

        // Move the player
        Vector3 pos = transform.position;
        float x = pos.x;
        float y = pos.y;

        y += speed * vertRaw;
        x += speed * horiRaw;

        // Check bound collisions
        PlayerCollisions playerCol = GetComponent<PlayerCollisions>();
        transform.position = playerCol.CheckBoundsCollision(new Vector3(x, y, pos.z));
    }
}
