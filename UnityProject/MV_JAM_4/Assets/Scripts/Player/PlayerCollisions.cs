using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour {

    public AudioSource sfx;
    public AudioClip[] deathSounds;

    // Use this for initialization
    void Start () {
        //sfx = GetComponent<AudioSource>();
        deathSounds = Resources.LoadAll<AudioClip>("Audio/SFX/deathscreams");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Kill()
    {
        if (sfx != null)
        {
            sfx.clip = deathSounds[Mathf.FloorToInt(Random.value * deathSounds.Length)];
            sfx.Play();
        }
        Destroy(gameObject);
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
