using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroupSpaceship : MonoBehaviour {

    public List<GameObject> myGroup;
    public Vector3 direction;
    public const int speed = 100;

    // Use this for initialization
    void Start () {
        NewDirection();
    }

    private void NewDirection()
    {
        if (transform.position.x < 0)
            direction.x = UnityEngine.Random.Range(0.0f, 20);
        else
            direction.x = UnityEngine.Random.Range(-20, 0.0f);
        direction.y -= 5;
        direction = direction.normalized;
    }

    // Update is called once per frame
    void Update () {
        /*if (myGroup[0].gameObject == this.gameObject)
        {
            
        }*/
        MoveTo(direction);
    }

    private void MoveTo(Vector3 dir)
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed * Time.deltaTime;
        if (direction != Vector3.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    public void SetGroup(List<GameObject> group)
    {
        myGroup = group;
    }
}
