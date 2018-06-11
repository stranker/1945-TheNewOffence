using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    private const float minDistanceToScreenCenter = 0.1f;
    private Vector3 direction;

    // Use this for initialization
    void Start () {
        direction = -transform.position.normalized;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += direction * 4 * Time.deltaTime;
        if (transform.position.y < minDistanceToScreenCenter && transform.position.y > -minDistanceToScreenCenter)
        {
            GetComponent<CreateExplosion>().Create(transform.position, 1, 75, 1f, 0.5f);
            Destroy(gameObject);
        }
	}
}
