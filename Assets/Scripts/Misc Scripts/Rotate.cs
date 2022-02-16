using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Rotate : MonoBehaviour
    {
        float timer;
        const float time = 1;

        void Update()
        {
            transform.Rotate(Vector3.up, Time.deltaTime * 20);

            timer -= Time.deltaTime;
            if(timer < 0)
            {
                timer = time;
            }
        }




    }
