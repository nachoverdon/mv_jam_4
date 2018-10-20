using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
//[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {

    public float speed = 0.2f;
    public Vector2 bounds;
    private bool canMove = true;

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

        float horizontal = Input.GetAxis("Horizontal");
        bool up = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        bool down = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        bool left = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        bool right = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);

        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -horizontal * 15f));

        //Rigidbody2D rb = GetComponent<Rigidbody2D>();

        //rb.velocity = new Vector2(0f, 0f);

        Vector3 pos = transform.position;
        Vector3 newPos;
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

        newPos = new Vector3(x, y, pos.z);

        // X axis
        if (newPos.x <= -bounds.x)
        {
            newPos = new Vector3(-bounds.x, newPos.y, newPos.z);
        }
        else if (newPos.x >= bounds.x)
        {
            newPos = new Vector3(bounds.x, newPos.y, newPos.z);
        }

        // Y axis
        if (newPos.y <= -bounds.y)
        {
            newPos = new Vector3(newPos.x, -bounds.y, newPos.z);
        }
        else if (newPos.y >= bounds.y)
        {
            newPos = new Vector3(newPos.x, bounds.y, newPos.z);
        }

        transform.position = newPos;

    }

    void CheckCollisionBounds()
    {
        SpriteRenderer spr = GetComponent<SpriteRenderer>();
        Vector2 spriteSize = new Vector2(spr.sprite.rect.width, spr.sprite.rect.height);
        Camera cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Vector3 pos = cam.WorldToScreenPoint(transform.position);

        if (pos.x - spriteSize.x / 2 < 0)
        {
            Debug.Log("left");
            transform.position = cam.ScreenToWorldPoint(new Vector3(spriteSize.x / 2 + 2, pos.y, pos.z));
            Debug.Log(transform.position.x);

        }
    }

    //void OnTriggerStay2D()
    //{
    //    CheckCollisionBounds();
    //}

    //void OnTriggerEnter2D()
    //{
    //    CheckCollisionBounds();
    //}
    //void OnTriggerExit2D()
    //{
    //    CheckCollisionBounds();
    //}

    //void OnCollisionEnter2D(Collision2D col)
    //{
    //    if (col.collider is BoxCollider2D) Debug.Log("this: Box");
    //    if (col.otherCollider is BoxCollider2D) Debug.Log("other: Box");
    //    if (col.collider is CapsuleCollider2D) Debug.Log("other: Capsule");
    //    if (col.otherCollider is CapsuleCollider2D) Debug.Log("other: Capsule");
    //    //Debug.Log();
    //    //Debug.Log(col.otherCollider is BoxCollider2D);
    //    CheckCollisionBounds(col);
    //}
}
