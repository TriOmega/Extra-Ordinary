using UnityEngine;

public class HealthPickUp : PickUps
{
    public int pickUpHealthWorth = 20;

    public override void PickUpEffect(GameObject player)
    {
        player.GetComponent<PlayerHealth>().AdjustCurrentHealth(pickUpHealthWorth);
    }
}
