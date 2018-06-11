using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPowerBullet : Collectable {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerAirplane player = collision.GetComponent<PlayerAirplane>();
            player.SetBulletPower(player.GetBulletPower() + 1);
            GameManager.Get().itemsCollected++;
            Destroy(gameObject);
        }
    }
}
