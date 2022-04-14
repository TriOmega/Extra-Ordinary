using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PuzzleCandle : MonoBehaviour
{
    public event EventHandler onCandleLit;

    [SerializeField, Tooltip("Place candle lights object here.")]
    private GameObject candleLights;
    public bool isCandleLit = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flashlight"))
        {
            isCandleLit = true;
            candleLights.SetActive(true);
            onCandleLit?.Invoke(this, EventArgs.Empty);
        }
    }

    public void BlowOutCandle()
    {
        isCandleLit = false;
        candleLights.SetActive(false);
    }
}
