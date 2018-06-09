using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    private Vector3 direction;
    const float minDistanceToScreenCenter = 0.1f;
    public GameObject explosionPrefab;
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
