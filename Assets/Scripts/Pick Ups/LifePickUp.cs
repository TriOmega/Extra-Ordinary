using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePickUp : PickUps
{
    public int pickUpLifeWorth = 1;

    public override void PickUpEffect(GameObject player)
    {
        player.GetComponent<PlayerHealth>().AdjustCurrentLives(pickUpLifeWorth);
    }
}
