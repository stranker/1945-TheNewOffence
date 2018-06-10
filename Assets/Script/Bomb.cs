using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    public GameObject explosionPrefab;
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
            GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation, transform.parent);
            explosion.GetComponent<Explosion>().SetEndTime(2);
            Destroy(gameObject);
        }
	}
}
