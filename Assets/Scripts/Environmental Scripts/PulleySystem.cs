using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulleySystem : MonoBehaviour
{
    [SerializeField]
    private GameObject chainBase;
    [SerializeField]
    private GameObject raisingWall;
    
    public void RaiseWall()
    {
        chainBase.transform.Translate(0f, -.5f, 0f);
        raisingWall.transform.Translate(0f, 2.5f, 0f);
    }
}
