using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroupSpaceship : MonoBehaviour
{
    public Vector3 direction;
    public const int speed = 100;
    public int changeDirectionTime = 3;
    public float timer;
    public bool leader = false;
    public int id;
    public float minDistance = 0.5f;
    public int score = 100;

    // Update is called once per frame
    void Update()
    {
        if (leader)
        {
            timer += Time.deltaTime;
            if (timer > changeDirectionTime)
            {
                NewDirection();
                timer = 0;
            }
            MoveTo(direction);
        }
        else
        {
            if (transform.parent.GetComponent<EnemyGroup>().GetNextShip(id) != null)
            {
                Vector3 vectorDirection = transform.parent.GetComponent<EnemyGroup>().GetNextShip(id).transform.position - transform.position;
                direction = vectorDirection.normalized;
                if (vectorDirection.magnitude > minDistance)
                    MoveTo(direction);
            }
            else
                leader = true;
        }
        CheckBoundaries();
    }

    private void MoveTo(Vector3 dir)
    {
        GetComponent<Rigidbody2D>().velocity = dir * speed * Time.deltaTime;
        if (direction != Vector3.zero)
        {
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void NewDirection()
    {
        if (transform.position.x < 0)
            direction.x = UnityEngine.Random.Range(0f, 1f);
        else
            direction.x = UnityEngine.Random.Range(-1f, 0f);
        direction.y -= 0.5f;
        direction = direction.normalized;
    }

    public Vector3 GetDirection()
    {
        return direction;
    }

    public void SetLeader(bool val)
    {
        leader = val;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            OnKill();
        }
        else if (collision.tag == "Explosion")
        {
            OnKill();
        }
    }

    private void CheckBoundaries()
    {
        float heightCamera = 2f * Camera.main.orthographicSize;
        if (transform.position.y < -heightCamera / 2)
            Destroy(gameObject);
    }

    public void OnKill()
    {
        GameManager.Get().levelScore += score;
        GameManager.Get().levelEnemiesKilled++;
        Destroy(gameObject);
    }

}
