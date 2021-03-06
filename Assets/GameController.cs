using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;


    TimeSpan timePlaying;
    public Text timeCounter;
    public bool gamePlaying { get; private set; }
    private float startTime, elapsedTime;

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

        if (gamePlaying)
        {
            elapsedTime = Time.time - startTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);

            string timePlayingStr = "Time: " + timePlaying.ToString("mm' : 'ss'.'ff");
            timeCounter.text = timePlayingStr;
        }
    }


}