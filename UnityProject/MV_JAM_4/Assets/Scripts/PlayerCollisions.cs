using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerCollisions : MonoBehaviour {

    public Vector2 bounds; // 9.215    4.76

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Vector3 CheckBoundsCollision(Vector3 pos)
    {
        // X axis
        if (pos.x <= -bounds.x)
        {
            pos = new Vector3(-bounds.x, pos.y, pos.z);
        }
        else if (pos.x >= bounds.x)
        {
            pos = new Vector3(bounds.x, pos.y, pos.z);
        }

        // Y axis
        if (pos.y <= -bounds.y)
        {
            pos = new Vector3(pos.x, -bounds.y, pos.z);
        }
        else if (pos.y >= bounds.y)
        {
            pos = new Vector3(pos.x, bounds.y, pos.z);
        }

        return pos;
    }

    void Kill()
    {
        // Make sound
        Destroy(gameObject);
        //GameController controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        //controller
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().GameOver();;
    }

    void CheckPlanetCollision(Collider2D col)
    {
        if (col.tag == "Planet")
        {
            Kill();
        }
    }

    void CheckSunCollision(Collider2D col)
    {
        if (col.tag == "Sun")
        {
            Kill();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        CheckPlanetCollision(col);
        CheckSunCollision(col);
    }


}
