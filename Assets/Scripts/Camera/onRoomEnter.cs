#if !UNITY_2019_3_OR_NEWER
#define CINEMACHINE_PHYSICS
#define CINEMACHINE_PHYSICS_2D
#endif

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using System;



namespace Cinemachine
{


    public class OnRoomEnter : MonoBehaviour
    {

        public GameObject CinemachineCamera;
        public Collider CameraConfinerBox;
        


        private void OnTriggerEnter(Collider other)
        { 
            if (other.gameObject.CompareTag ("Player"))
            {
                //Change cinemachine confiner bounding volume property
                CinemachineCamera.GetComponent<CinemachineConfiner>().m_BoundingVolume = CameraConfinerBox;
            }
        }


    }
}