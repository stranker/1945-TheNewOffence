using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEnergy : MonoBehaviour {

    public const int quantity = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerAirplane>().energy++;
            Destroy(gameObject);
        }
    }

}
