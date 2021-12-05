using UnityEngine;

public class PickUps : MonoBehaviour
{
    public bool canBePaddleBalled = false;
    private MoveToPlayer moveToPlayer;

    public void Start()
    {
        moveToPlayer = GetComponent<MoveToPlayer>();
        moveToPlayer.enabled = (canBePaddleBalled ? true : false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject _player = other.gameObject;
            PickUpEffect(_player);
            Destroy(gameObject);
        }
    }
    
    public virtual void PickUpEffect(GameObject playerRef) { }
}
