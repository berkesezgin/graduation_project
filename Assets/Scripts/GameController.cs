using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public Transform ball;
    TimeSpan timePlaying;
    public Text timeCounter;
    public bool gamePlaying { get; private set; }
    private float startTime, elapsedTime;
    private string finalTime;
    public static string showFinalTime;
    private string timePlayingStr;
    public static int totalSeconds;
    public static string status;

    private void Awake()
    {
        instance = this;
    }
    private void BeginGame()
    {
        gamePlaying = true;
        startTime = Time.time;

    }
    // Start is called before the first frame update
    private void Start()
    {
        gamePlaying = false;
        BeginGame();

    }

    // Update is called once per frame
    private void Update()
    {

        if (gamePlaying == true && ball != null)
        {
            elapsedTime = Time.time - startTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);

            timePlayingStr = timePlaying.ToString("mm' : 'ss'.'ff");
            timeCounter.text = timePlayingStr;
        }
        if (ball == null)
        {
            finalTime = timePlayingStr;
            showFinalTime = finalTime;
            Debug.Log(finalTime);

            totalSeconds = (int) timePlaying.TotalSeconds;

            if (totalSeconds < 10)
            {
                status = "Great Job!";
            }
            else 
            {
                status = "Needs to be improved";
            }
        }
    }
}