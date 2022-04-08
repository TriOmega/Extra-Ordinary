using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamepadCursor : MonoBehaviour
{
    private bool isGamepadConnected = false;


    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckForGamepad());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator CheckForGamepad()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(3f);

            string[] joystickArray = Input.GetJoystickNames();
            if (joystickArray.Length > 0)
            {
                for(int i = 0; i < joystickArray.Length; i++)
                {
                    if (!string.IsNullOrEmpty(joystickArray[i]))
                    {
                        isGamepadConnected = true;
                        Debug.Log("Gamepad Connected.");
                    }
                    else
                    {
                        isGamepadConnected = false;
                        Debug.Log("Gamepad Disconnected.");
                    }
                }
            }
            else
            {
                isGamepadConnected = false;
            }
        }
    }
}
