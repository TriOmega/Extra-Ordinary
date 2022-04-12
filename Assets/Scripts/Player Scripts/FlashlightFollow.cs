using UnityEngine;
using System.Collections;

public delegate void StunEventHandler();

public class FlashlightFollow : MonoBehaviour
{
    [SerializeField]
    private GamepadCursor gamepadCursor;
    [SerializeField]
    private GameObject lightContainer;
    private bool isLightOn = true;

    Ray ray;
    public RaycastHit hit;

    private GameObject lightObject;
    private Light myLightComponent;

    [SerializeField]
    private float lookTurnSpeed = 180.0f;

    //ArrayList layerNames = new ArrayList();
    //string[] namedLayers;
    //LayerMask flashlightTargetedLayers;
    //int flashlightTargetedLayers;

    public event StunEventHandler StunEvent;

    private void Start()
    {
        //int excludedLayer = LayerMask.NameToLayer("Checkpoints");
        //flashlightTargetedLayers = 1 << excludedLayer;
        //flashlightTargetedLayers = ~flashlightTargetedLayers;
        //for (int i = 7; i <= 31; i++)
        //{
        //    var layerN = LayerMask.LayerToName(i);
        //    if (layerN.Length > 0 && !layerN.Equals("Checkpoints"))
        //    {
        //        layerNames.Add(layerN);
        //    }
        //}
        //namedLayers = (string[]) layerNames.ToArray(typeof(string));
        //flashlightTargetedLayers = LayerMask.GetMask(namedLayers);
        lightObject = GameObject.Find("Spot Light");
        myLightComponent = lightObject.GetComponent<Light>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("SpecialAttack"))
        {
            isLightOn = !isLightOn;
            lightContainer.SetActive(isLightOn);
        }
    }

    void FixedUpdate()
    {
        ray = Camera.main.ScreenPointToRay(gamepadCursor.IsGamepadConnected == true ? gamepadCursor.CursorRectTransform.position : Input.mousePosition);
        bool didHit = Physics.Raycast(ray, out hit);
        //Vector3 directionToTarget = transform.position - hit.point;
        //float angle = Vector3.Angle(transform.forward, directionToTarget);

        if (didHit)
        {
            //print(ray.direction);
            transform.LookAt(hit.point);
            if (hit.collider.gameObject.GetComponent<IStunnable>() != null)
            {
                hit.collider.gameObject.GetComponent<IStunnable>().Stun();
            }
        }
    } 
}