using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private int speed;
    private float timer = 0;
    public float endTime;
    private Vector3 initialScale = new Vector3(0.5f, 0.5f, 1);

    private void Start()
    {
        transform.localScale = initialScale;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer <= endTime)
            transform.localScale += initialScale * speed * Time.deltaTime;
        else
            Destroy(gameObject);
    }

    public void Initialize(float duration, int spd)
    {
        endTime = duration;
        speed = spd;
    }
}
