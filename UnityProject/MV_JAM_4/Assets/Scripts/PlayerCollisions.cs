using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour {

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
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
