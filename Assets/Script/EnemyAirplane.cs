using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAirplane : MonoBehaviour
{
    const int speed = 4;
    public Vector3 direction;
    public int minDistance = 3;
    private GameObject player;
    public bool isChasing = true;
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
        Destroy(gameObject);
    }

    private void Movement()
    {
        Vector3 movement = Vector3.zero;
        float distanceToPlayer = Mathf.Abs(player.transform.position.y - transform.position.y);
        if (distanceToPlayer > minDistance && isChasing)
            direction = (player.transform.position - transform.position).normalized;
        else
            isChasing = false;
        movement = direction * speed * Time.deltaTime;
        transform.position += movement;
    }
}
