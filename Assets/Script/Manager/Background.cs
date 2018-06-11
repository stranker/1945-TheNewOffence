using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    public float speed = 10f;
    public Vector2 offset = Vector2.zero;

    void Update () {
        offset.y += Time.deltaTime * speed;
        GetComponent<SpriteRenderer>().material.mainTextureOffset = offset;
    }
}
