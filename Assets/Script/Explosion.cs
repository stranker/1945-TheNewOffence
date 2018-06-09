using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    // Use this for initialization
    private const int speed = 100;
    private float timer = 0;
    public int endTime;
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer <= endTime)
            transform.localScale += new Vector3(1, 1, 0) * speed * Time.deltaTime;
        else
            Destroy(gameObject);
    }

    public void SetEndTime(int val)
    {
        endTime = val;
    }
}
