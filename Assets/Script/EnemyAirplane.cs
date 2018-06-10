using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAirplane : MonoBehaviour
{
    public int speed = 4;
    public Vector3 direction;
    public int minDistance = 3;
    public bool isChasing = true;
    public int score = 200;
    private GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameManager.Get().player;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
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

    private void Movement()
    {
        Vector3 movement = Vector3.zero;
        float distanceToPlayer = Mathf.Abs(player.transform.position.y - transform.position.y);
        if (distanceToPlayer > minDistance)
            direction = (player.transform.position - transform.position).normalized;
        movement = direction * speed * Time.deltaTime;
        transform.position += movement;
    }

    private void OnDestroy()
    {
        GameManager.Get().SetScore(GameManager.Get().GetScore() + score);
    }

}
