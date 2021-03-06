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

    public class CameraForBoss : MonoBehaviour
    {
        public GameObject CinemachineCamera;
        public Collider CameraConfinerBox;
        public GameObject EnableWall;
        public GameObject DisableCamera;


        


        private void OnTriggerEnter(Collider other)
        { 
            if (other.gameObject.CompareTag ("Player"))
            {
                //Change cinemachine confiner bounding volume property
                CinemachineCamera.GetComponent<CinemachineConfiner>().m_BoundingVolume = CameraConfinerBox;

                EnableWall.SetActive(true);
                DisableCamera.SetActive(false);

            }
        }
    }
}
