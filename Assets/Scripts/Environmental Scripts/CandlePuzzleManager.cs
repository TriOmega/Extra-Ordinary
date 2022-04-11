using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class CandlePuzzleManager : MonoBehaviour
{
    [SerializeField]
    private float candleTimerSeconds;
    [SerializeField]
    private AudioClip candleFlickerSFX;
    [SerializeField]
    private AudioClip candleBlowOutSFX;
    [SerializeField]
    private AudioSource candlePuzzleAudioSource;

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

        if (litCandleCount == candlesInPuzzle.Count)
        {
            StopCoroutine(timerCoroutine);
            candlePuzzleAudioSource.enabled = false;
            Debug.Log("Door Unlocked!");
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

        yield return new WaitForSecondsRealtime(candleTimerSeconds);

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
