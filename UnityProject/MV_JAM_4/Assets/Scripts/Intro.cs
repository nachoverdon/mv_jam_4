using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("LoadGameScene", 3f);
	}
	
	// Update is called once per frame
	void LoadGameScene () {
        SceneManager.LoadScene("GameScene");
	}
}
