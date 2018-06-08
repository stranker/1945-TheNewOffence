using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirplane : MonoBehaviour
{
    public int speed = 6;
    public GameObject bulletPrefab;
    public GameObject bombPrefab;
    public float shootingTime;
    public bool canShoot = true;
    private const float resetShootTime = 0.2f;
    private Vector3 movement = Vector3.zero;
    public List<GameObject> cannons = new List<GameObject>();
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shoot();
        BombDrop();
        CheckCanShoot();
    }

    private void BombDrop()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bombPrefab, transform.position, transform.rotation, transform.parent);
        }
    }

    private void CheckCanShoot()
    {
        if (!canShoot)
            shootingTime += Time.deltaTime;
        if (shootingTime >= resetShootTime)
        {
            canShoot = true;
            shootingTime = 0;
        }
    }

    private void Shoot()
    {
        if (Input.GetKey(KeyCode.S) && canShoot)
        {
            canShoot = false;
            for (int i = 0; i < cannons.Count; i++)
            {
                GameObject b = Instantiate(bulletPrefab, cannons[i].transform.position, transform.rotation, transform.parent);
                b.GetComponent<Bullet>().SetDirectionY(1);
            }
        }
    }

    private void Movement()
    {
        float heightCamera = 2f * Camera.main.orthographicSize;
        float widthCamera = heightCamera * Camera.main.aspect;
        float halfSizeSpriteW = GetComponent<SpriteRenderer>().bounds.size.x / 2;
        float halfSizeSpriteH = GetComponent<SpriteRenderer>().bounds.size.y / 2;
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        Vector3 newPos = transform.position + movement * speed * Time.deltaTime;
        newPos.x = Mathf.Clamp(newPos.x, -widthCamera / 2 + halfSizeSpriteW, widthCamera / 2 - halfSizeSpriteW);
        newPos.y = Mathf.Clamp(newPos.y, -heightCamera / 2 + halfSizeSpriteH, heightCamera / 2 - halfSizeSpriteH);
        transform.position = newPos;
    }
}
