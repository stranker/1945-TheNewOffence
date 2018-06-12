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
    public List<GameObject> cannons;
    public int activeCannons = 1;
    public int energy;
    public const int MAX_ENERGY = 10;
    public int bulletPower = 1;
    public int bombs = 1;
    private const int clampY = 1;
    public const float bulletDispersion = 1f;
    public bool canBeHit = true;
    public int flickTime = 3;
    public float timer;

    private void Start()
    {
        energy = MAX_ENERGY;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shoot();
        BombDrop();
        CheckCanShoot();
        CheckHit();
    }

    private void CheckHit()
    {
        if (!canBeHit)
            timer = Time.deltaTime;
        if (timer >= flickTime)
        {
            timer = 0;
            canBeHit = true;
        }
    }

    private void BombDrop()
    {
        if (Input.GetKeyDown(KeyCode.Space) && bombs > 0)
        {
            Instantiate(bombPrefab, transform.position, transform.rotation, transform.parent);
            bombs--;
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
        if (Input.GetKey(KeyCode.F) && canShoot)
        {
            canShoot = false;
            foreach (GameObject cannon in cannons)
            {
                if (cannon.activeInHierarchy)
                {
                    GameObject b = Instantiate(bulletPrefab, cannon.transform.position, transform.rotation, transform.parent);
                    b.GetComponent<Bullet>().Initialize(1, bulletPower, bulletDispersion);
                }
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
        newPos.y = Mathf.Clamp(newPos.y, -heightCamera / 2 + clampY + halfSizeSpriteH, heightCamera / 2 - clampY - halfSizeSpriteH);
        transform.position = newPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            canBeHit = false;
            Destroy(collision.gameObject);
            energy--;
        }
    }

    public void AddBulletPower()
    {
        bulletPower++;
    }

    public void SetBulletPower(int val)
    {
        bulletPower = val;
    }

    public int GetBulletPower()
    {
        return bulletPower;
    }

    public void SetEnergy(int val)
    {
        energy = val;
        if (energy > MAX_ENERGY)
            energy = MAX_ENERGY;
    }

    public int GetEnergy()
    {
        return energy;
    }

    public int GetBombs()
    {
        return bombs;
    }

    public int GetMaxEnergy()
    {
        return MAX_ENERGY;
    }

    public void AddCannons()
    {
        activeCannons += 2;
        if (activeCannons > cannons.Count)
            activeCannons = cannons.Count;
        for (int i = 0; i < activeCannons; i++)
            cannons[i].SetActive(true);
    }
}
