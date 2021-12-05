using UnityEngine;

public class FlashlightFollow : MonoBehaviour
{

    Ray ray;
    RaycastHit hit;

    private GameObject lightObject;
    private Light myLightComponent;

    [SerializeField]
    private float lookTurnSpeed = 180.0f;

    private void Start()
    {
        lightObject = GameObject.Find("Spot Light");
        myLightComponent = lightObject.GetComponent<Light>();
    }

    void Update()
    {
        float verticalInputDirection = Input.GetAxis("VerticalLookDirection");

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            //print(hit.collider.name);
            transform.LookAt(hit.point);
        }

        if (Input.GetButtonDown("SpecialAttack"))
            myLightComponent.enabled = !myLightComponent.enabled;

        if (verticalInputDirection != 0)
        {
            transform.Rotate(Vector3.left, verticalInputDirection * lookTurnSpeed * Time.deltaTime, Space.Self);            //Possible future bug: dependency on Time.deltaTime could cause strange results on slower computers
        }
    } 
}