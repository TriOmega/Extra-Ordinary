using UnityEngine;

public class PickUps : MonoBehaviour
{
    public bool canBePaddleBalled = false;
    private MoveToPlayer moveToPlayer;

    public float amplitude;
    public float speed;
    private float tempVal;
    private Vector3 tempPos;
    public bool isFloating = true;

    private void Start()
    {
        moveToPlayer = GetComponent<MoveToPlayer>();
        moveToPlayer.enabled = (canBePaddleBalled ? true : false);
        tempVal = transform.position.y;
        tempPos = transform.position;
    }

    void FixedUpdate()
    {
        if (isFloating)
        {
            tempPos.y = tempVal + amplitude * Mathf.Sin(speed * Time.time);
            transform.position = tempPos;
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject _player = other.gameObject;
            PickUpEffect(_player);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "ball")
        {
            isFloating = false;
        }
    }
    
    public virtual void PickUpEffect(GameObject playerRef) { }
}
