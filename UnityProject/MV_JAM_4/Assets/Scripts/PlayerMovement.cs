using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
//[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {

    public float speed = 0.2f;
    private bool canMove = true;
    public Vector4 bounds;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        //CheckCollision();
        CheckMovement();
        
	}

    void CheckMovement()
    {
        if (!canMove)
        {
            canMove = true;
            return;
        }

        bool up = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        bool down = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        bool left = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        bool right = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);

        //Rigidbody2D rb = GetComponent<Rigidbody2D>();

        //rb.velocity = new Vector2(0f, 0f);

        Vector3 pos = transform.position;
        float x = pos.x;
        float y = pos.y;

        if (up)
        {
            y += speed;
        }
        else if (down)
        {
            y -= speed;
        }

        if (left)
        {
            x -= speed;
        }
        else if (right)
        {
            x += speed;
        }

        transform.position = new Vector3(x, y, pos.z);

    }

    void CheckCollisionBounds(Collision2D col)
    {
        if (col.gameObject.tag == "Bounds")
        {
            //canMove = false;
        }
    }

    void OnTriggerEnter()
    {
        BoxCollider2D col = GetComponent<BoxCollider2D>();
        Debug.Log("test");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider is BoxCollider2D) Debug.Log("this: Box");
        if (col.otherCollider is BoxCollider2D) Debug.Log("other: Box");
        if (col.collider is CapsuleCollider2D) Debug.Log("other: Capsule");
        if (col.otherCollider is CapsuleCollider2D) Debug.Log("other: Capsule");
        //Debug.Log();
        //Debug.Log(col.otherCollider is BoxCollider2D);
        CheckCollisionBounds(col);
    }
}
