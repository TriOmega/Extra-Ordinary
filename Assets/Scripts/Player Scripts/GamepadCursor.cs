using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamepadCursor : MonoBehaviour
{

    [SerializeField]
    public bool IsGamepadConnected { get => isGamepadConnected; }
    public RectTransform CursorRectTransform { get => cursorRectTransform; }

    private Vector3 direction = Vector2.zero;
    private float cursorSpeed = 5;
    
    void Start()
    {
        StartCoroutine(CheckForGamepad());
        cursorRectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.Set(Input.GetAxis("HorizontalLookDirection"), Input.GetAxis("VerticalLookDirection"), 0);
        Vector3 newPosition = cursorRectTransform.position + direction * cursorSpeed;
        newPosition.x = Mathf.Clamp(newPosition.x, 0, Screen.width);
        newPosition.y = Mathf.Clamp(newPosition.y, 0, Screen.height);
        cursorRectTransform.position = newPosition;
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
                        GetComponent<Image>().enabled = true;
                        Debug.Log("Gamepad Connected.");
                    }
                    else
                    {
                        isGamepadConnected = false;
                        GetComponent<Image>().enabled = false;
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

    private bool isGamepadConnected = false;
    private RectTransform cursorRectTransform;
}
