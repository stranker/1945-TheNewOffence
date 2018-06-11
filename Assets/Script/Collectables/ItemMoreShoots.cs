using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMoreShoots : Collectable {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerAirplane player = collision.GetComponent<PlayerAirplane>();
            GameManager.Get().itemsCollected++;
            player.AddCannons();
            Destroy(gameObject);
        }
    }
}
