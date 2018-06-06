using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirplane : MonoBehaviour
{
    public int speed = 6;
    public float xMin, xMax, yMin, yMax;
    public GameObject bulletPrefab;
    public float shootingTime;
    public bool canShoot = true;
    private const float resetShootTime = 0.1f;
    private Vector3 movement = Vector3.zero;
    private GameObject firstCanon;
    // Use this for initialization
    void Start()
    {
        firstCanon = GameObject.Find("FirstCanon");
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shoot();
        CheckCanShoot();
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
        if (Input.GetKey(KeyCode.Space) && canShoot)
        {
            canShoot = false;
            GameObject b = Instantiate(bulletPrefab, firstCanon.transform.position, transform.rotation, transform.parent);
            b.GetComponent<Bullet>().SetDirectionY(1);
        }
    }

    private void Movement()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        Vector3 newPos = transform.position + movement * speed * Time.deltaTime;
        newPos.x = Mathf.Clamp(newPos.x, xMin, xMax);
        newPos.y = Mathf.Clamp(newPos.y, yMin, yMax);
        transform.position = newPos;
    }
}
