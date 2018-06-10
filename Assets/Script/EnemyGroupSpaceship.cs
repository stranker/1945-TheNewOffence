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
            Destroy(gameObject);
            Destroy(collision.gameObject);
            GetComponent<DropItems>().DropItem(transform.position);
        }
        else if (collision.tag == "Explosion")
        {
            Destroy(gameObject);
            GetComponent<DropItems>().DropItem(transform.position);
        }
    }

    private void OnDestroy()
    {
        GameManager.Get().SetScore(GameManager.Get().GetScore() + score);
    }

}
