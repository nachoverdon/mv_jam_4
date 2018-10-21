using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlanetSprite : MonoBehaviour {

    void Start()
    {
        var sprites = Resources.LoadAll<Sprite>("Textures/planets");
        GetComponent<SpriteRenderer>().sprite = sprites[Mathf.FloorToInt(Random.value * sprites.Length)];
    }
}
