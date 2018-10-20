using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class PlanetCollisions : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter2D(Collider2D col)
    {
        CheckSunCollision(col);
    }

    void CheckSunCollision(Collider2D col)
    {
        if (col.tag == "Sun")
        {
            GameObject controllerGO = GameObject.FindGameObjectWithTag("GameController");
            GameController controller = controllerGO.GetComponent<GameController>();
            Score score = controllerGO.GetComponent<Score>();
            Destroy(transform.parent.gameObject);
            controller.SpawnOrbit();
            Vector3 scale = col.gameObject.transform.localScale;
            scale = new Vector3(scale.x + 0.05f, scale.y + 0.05f, scale.z);
            col.gameObject.transform.localScale = scale;
            score.IncreaseScore(1);
        }
    }
}
