using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public string scoreDisplay;
    private Text scoreText;
    private int score = 0;

	// Use this for initialization
	void Start () {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        score = 0;
        SetText();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void IncreaseScore(int amount)
    {
        if (GameObject.Find("Player") != null)
        {
            score += amount;
            SetText();
        }
    }

    public int GetScore()
    {
        return score;
    }

    void SetText()
    {
        scoreText.text = scoreDisplay + score;
    }
}
