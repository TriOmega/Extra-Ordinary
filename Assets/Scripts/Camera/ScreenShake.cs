#if !UNITY_2019_3_OR_NEWER
#define CINEMACHINE_PHYSICS
#define CINEMACHINE_PHYSICS_2D
#endif

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

// namespace Cinemachine
// {
//     public class ScreenShake : MonoBehaviour
//     {        
//         private CinemachineVirtualCamera cinemachineVirtualCamera;
//         private float shakeTimer;  //How long the screen shakes for. 

//         private void Awake()
//         {
//             cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
//         }

//         public void ShakeCamera(float intensity, float time)
//         {
//             CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin=
//             cinemachineVirtualCamera.GetCinemachineComponet<CinemachineBasicMultiChannelPerlin>();

//             cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
//             shakeTimer = time;
//         }





//         private void Update()
//         {
//             if(shakeTimer > 0)
//             {
//                 shakeTimer -= Time.deltaTime;
//                 if(shakeTimer <= 0f)
//                 {
//                     CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin=
//                     cinemachineVirtualCamera.GetCinemachineComponet<CinemachineBasicMultiChannelPerlin>();

//                     cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
//                 }
//             }
//         }
//     }

// }
