﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    static Object orbitPrefab;
    private GameObject orbits;
    public AudioSource gameOverSound;
    public int orbitsAmount;
    public float maxTranslationSpeed;
    public float orbitInitRadius;
    public float orbitSeparation;
    public float orbitSpeedMultiplier;
    private int orbitsSpawned = 0;
    private bool isGameOver = false;


    // Use this for initialization
    void Start()
    {
        gameOverSound = GetComponent<AudioSource>();
        orbitPrefab = Resources.Load("Prefabs/Orbit");
        orbits = GameObject.FindGameObjectWithTag("Orbits");

        for (int i = 1; i < orbitsAmount; i++)
        {
            var orbit = SpawnOrbit();
            orbit.radius = orbitInitRadius + i * orbitSeparation;
            orbit.translationSpeed += Random.Range(-5, 5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            if (Input.GetKey(KeyCode.F5) || Input.GetKey(KeyCode.R))
                SceneManager.LoadScene("GameScene");
        }
    }

    public PlanetOrbit SpawnOrbit()
    {
        GameObject orbitGO = (GameObject)Instantiate(orbitPrefab);
        PlanetOrbit orbit = orbitGO.transform.Find("Planet").GetComponent<PlanetOrbit>();

        orbit.axis = new Vector3(0f, 0f, Random.Range(-1f, 1) * 1);
        orbit.radius = orbitInitRadius;
        orbit.translationSpeed += (orbitsSpawned * orbitSpeedMultiplier);

        if (orbit.translationSpeed >= maxTranslationSpeed)
            orbit.translationSpeed = maxTranslationSpeed;

        PlanetShrink shrink = orbitGO.transform.Find("Planet").GetComponent<PlanetShrink>();
        shrink.radiusShrinkSpeed += (orbitsSpawned * 0.0005f);

        float angle = Random.value * Mathf.PI * 2;

        orbit.SetPosition(
            new Vector3(
                Mathf.Cos(angle) * orbitInitRadius,
                Mathf.Sin(angle) * orbitInitRadius,
                orbit.transform.position.z
            )
        );
        orbitGO.transform.SetParent(orbits.transform);
        orbitsSpawned++;

        return orbit;
    }

    public void GameOver()
    {
        GameObject deathTextGO = GameObject.Find("DeathText");
        if (deathTextGO != null)
        {
            //deathTextGO.SetActive(true);
            deathTextGO.transform.position = new Vector3(0, 0, 0);
            isGameOver = true;
        }
        gameOverSound.Play();
        // Stop score count
    }
}
