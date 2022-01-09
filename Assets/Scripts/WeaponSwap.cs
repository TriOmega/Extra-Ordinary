using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwap : MonoBehaviour
{
    public int selectedWeapon = 0;
    private bool canSwapAbility = false;

    public GameObject GumIcon;
    public GameObject FlashlightIcon;
    public GameObject PaddleballIcon;


    void Start()
    {
        SelectWeapon();
    }


    void Update()
    {

        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetAxis("JoystickAbilitySwap") == 0f)
        {
            canSwapAbility = true;
        }

        if (Input.GetAxis("MouseAbilitySwap") > 0f || (Input.GetAxis("JoystickAbilitySwap") > 0f && canSwapAbility == true))
        {
            canSwapAbility = false;

            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }
        if (Input.GetAxis("MouseAbilitySwap") < 0f || (Input.GetAxis("JoystickAbilitySwap") < 0f && canSwapAbility == true))
        {
            canSwapAbility = false;

            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }

        if (selectedWeapon == 0)
        {
            GumIcon.SetActive(true);
            FlashlightIcon.SetActive(false);
            PaddleballIcon.SetActive(false);
        }

        else if (selectedWeapon == 1)
        {
            GumIcon.SetActive(false);
            FlashlightIcon.SetActive(true);
            PaddleballIcon.SetActive(false);
        }

        else 
        {
            GumIcon.SetActive(false);
            FlashlightIcon.SetActive(false);
            PaddleballIcon.SetActive(true);
        }
    }

    void SelectWeapon()
    {

        int i = 0;

        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
