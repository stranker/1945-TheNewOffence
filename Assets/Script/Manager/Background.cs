using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    public List<Sprite> backgrounds;
    public float speed = 10f;
    public Vector2 offset = Vector2.zero;

    void Update () {
        offset.y += Time.deltaTime * speed;
        GetComponent<SpriteRenderer>().material.mainTextureOffset = offset;
    }

    public void SetBackgroundLevel(int level)
    {
        GetComponent<SpriteRenderer>().sprite = backgrounds[level];
    }

}
