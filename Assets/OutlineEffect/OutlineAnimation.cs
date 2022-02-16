using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class OutlineAnimation : MonoBehaviour
    {
        bool pingPong = false;


        void Update()
        {
            Color color = GetComponent<OutlineEffect>().lineColor0;

            if(pingPong == true)
            {
                color.a += Time.deltaTime;

                if(color.a >= 1)
                {
                    pingPong = false;
                }

            }
            else
            {
                color.a -= Time.deltaTime;

                if(color.a <= 0)
                {
                    pingPong = true;
                }

            }

            color.a = Mathf.Clamp01(color.a);
            GetComponent<OutlineEffect>().lineColor0 = color;
            GetComponent<OutlineEffect>().UpdateMaterialsPublicProperties();
        }
    }
