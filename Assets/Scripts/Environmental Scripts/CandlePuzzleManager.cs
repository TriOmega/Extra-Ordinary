using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class CandlePuzzleManager : MonoBehaviour
{
    [Header("Candle Puzzle Controls")]
    [SerializeField]
    private float candleTimerSeconds;
    [SerializeField]
    private AudioClip candleFlickerSFX;
    [SerializeField]
    private AudioClip candleBlowOutSFX;
    [SerializeField]
    private AudioClip successSFX;
    [SerializeField]
    private AudioSource candlePuzzleAudioSource;
    
    [Header("Door Controls")]
    [SerializeField]
    private GameObject door;
    [SerializeField]
    private float rotateAngle = 90f;
    private bool hasDoorUnlocked = false;

    [SerializeField, Tooltip("Place all puzzle candles used in this puzzle here.")]
    List<PuzzleCandle> candlesInPuzzle = new List<PuzzleCandle>();

    private Coroutine timerCoroutine;

    private void Start()
    {
        foreach (PuzzleCandle candle in candlesInPuzzle)
        {
            candle.onCandleLit += StartCandleTimer;
        }
    }

    //DEBUG PURPOSE
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("3_HauntedHouseScene");
        }
    }

    private void StartCandleTimer(object sender, EventArgs none)
    {
        int litCandleCount = HowManyCandlesAreLit();

        if (hasDoorUnlocked)
        {
            return;
        }

        if (litCandleCount == candlesInPuzzle.Count)
        {
            StopCoroutine(timerCoroutine);
            candlePuzzleAudioSource.clip = null;
            candlePuzzleAudioSource.PlayOneShot(successSFX);
            hasDoorUnlocked = true;
            door.transform.Rotate(Vector3.up * rotateAngle);  //This opens the door
        }
        else if (litCandleCount > 1)
        {
            return;
        }
        else
        {
            timerCoroutine = StartCoroutine(CandleTimer());
        }
    }

    public IEnumerator CandleTimer()
    {
        candlePuzzleAudioSource.loop = true;
        candlePuzzleAudioSource.clip = candleFlickerSFX;
        candlePuzzleAudioSource.Play();

        float f = 0f;
        
        while (f < candleTimerSeconds)
        {
            yield return new WaitForSecondsRealtime(candleTimerSeconds / 5);
            candlePuzzleAudioSource.volume -= .2f;
            f += candleTimerSeconds / 5;
        }

        candlePuzzleAudioSource.volume = 1f;
        candlePuzzleAudioSource.loop = false;
        candlePuzzleAudioSource.clip = candleBlowOutSFX;
        candlePuzzleAudioSource.Play();
        foreach(PuzzleCandle candle in candlesInPuzzle)
        {
            candle.BlowOutCandle();
        }
    }

    public int HowManyCandlesAreLit()
    {
        int counter = 0;
        foreach (PuzzleCandle candle in candlesInPuzzle)
        {
            if (candle.isCandleLit == true)
            {
                counter++;
            }
        }
        return counter;
    }
}
