using UnityEngine;

public class HealthPickUp : PickUps
{
    public int pickUpHealthWorth = 5;

    public override void PickUpEffect(GameObject player)
    {
        player.GetComponent<PlayerHealth>().AdjustCurrentHealth(pickUpHealthWorth);
    }
}
