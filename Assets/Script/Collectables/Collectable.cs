using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    public const int speed = 100;

    private void Update()
    {
        Move();
        CheckBoundaries();
    }

    private void CheckBoundaries()
    {
        float heightCamera = 2f * Camera.main.orthographicSize;
        if (transform.position.y < -heightCamera / 2)
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, -speed * Time.deltaTime);
    }

}
