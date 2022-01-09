using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public GameObject doorKey;    
    public GameObject door;
 

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            doorKey.SetActive(false);
            door.transform.Rotate(new Vector3(0, 75, 0) );

        }
    }




    
    

}
