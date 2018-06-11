using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEnergy : Collectable {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerAirplane player = collision.GetComponent<PlayerAirplane>();
            GameManager.Get().itemsCollected++;
            player.SetEnergy(player.GetEnergy() + 1);
            Destroy(gameObject);
        }
    }

}
