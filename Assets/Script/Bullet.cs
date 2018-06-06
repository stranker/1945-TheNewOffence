using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public const int speed = 6;
    public int dirY;
	// Update is called once per frame
	void Update () {
        Movement();
        CheckBoundaries();
	}

    private void CheckBoundaries()
    {
        Vector3 screenPos = Camera.main.WorldToViewportPoint(transform.position);
        if (screenPos.x < 0 || screenPos.y < 0 || screenPos.x > 1 || screenPos.y > 1)
            Destroy(gameObject);
    }

    private void Movement()
    {
        Vector3 movement = Vector3.zero;
        movement.y = dirY * speed;
        transform.position += movement * Time.deltaTime;
    }

    public void SetDirectionY(int val)
    {
        dirY = val;
    }
}
