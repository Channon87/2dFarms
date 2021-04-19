using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private Gradient lightColour;
    [SerializeField] private GameObject light;

    // Game Object Fields that allow us to change when the sunrise and sunset functions start in the inspector
    [SerializeField] private int sunriseHour;
    [SerializeField] private int sunriseMinutes;
    [SerializeField] private int sunriseSeconds;

    [SerializeField] private int sunsetHour;
    [SerializeField] private int sunsetMinutes;
    [SerializeField] private int sunsetSeconds;

    private int gameSecond;
    private int gameMinute;
    private int gameHour;
    private int gameDay;

    private float secondsPerGameSecond = 0.005f;

    private float gameTicker;
    private bool gamePaused;

    private int eventTimer;
    private bool sunriseInitiated;
    private bool sunsetInitiated;
    private float eventValue;

    // Start is called before the first frame update
    void Start()
    {
        this.gameDay = 0;
        this.gameHour = 18;
        this.gameMinute = 30;
        this.gameSecond = 0;
        Debug.Log("Game start time: " + gameHour + ":" + gameMinute + ":" + gameSecond);

        this.gameTicker = 0f;

        this.gamePaused = false;

        this.eventTimer = 0;

        this.sunsetInitiated = false;

        this.sunriseInitiated = false;
    }

    // Update is called once per frame
    void Update()
    {
        testerMethod();

        if (!gamePaused)
        {
            GameTicker();

            CheckForSunriseandSunset();

            if (sunriseInitiated == true)
            {
                CallSunriseMethod();
            }

            if (sunsetInitiated == true)
            {
                CallSunsetMethod();
            }
        }
    }

    private void GameTicker()
    {
        gameTicker += Time.deltaTime;

        if (gameTicker >= secondsPerGameSecond)
        {
            gameTicker -= secondsPerGameSecond;
            UpdateGameSecond();
        }
    }

    private void UpdateGameSecond()
    {
        gameSecond++;

        if (gameSecond > 59)
        {
            gameSecond = 0;
            gameMinute++;
            //            Debug.Log("Minute Increased to " + gameMinute);

            if (gameMinute > 59)
            {
                gameMinute = 0;
                gameHour++;
                Debug.Log("Hour Increased to " + gameHour);

                if (gameHour > 23)
                {
                    gameHour = 0;
                    gameDay++;
                }
            }
        }
    }

    // Dummy method to test that code is working - will be deleted later
    private void testerMethod()
    {
        if (gameDay == 3)
        {
            Debug.Log("Testing Window Ended");
            this.gamePaused = true;
        }
    }

    // Checks if in game time matches pre-determined sunset time, once true starts sunset function
    private void CheckForSunriseandSunset()
    {
        if (gameHour == sunriseHour && gameMinute == sunriseMinutes && gameSecond == sunriseSeconds)
        {
            Debug.Log("Sunrise Initiated");
            // Changing this to true will mean that the method is called every frame
            sunriseInitiated = true;
            eventValue = 0;
            eventTimer = 50;
        }

        if (gameHour == sunsetHour && gameMinute == sunsetMinutes && gameSecond == sunsetSeconds)
        {
            Debug.Log("Sunset Initiated");
            // Changing this to true will mean that the method is called every frame
            sunsetInitiated = true;
            eventValue = 0;
            eventTimer = 0;
        }
    }

    private void CallSunsetMethod()
    {
        eventValue += Time.deltaTime;

        //if (eventValue >= secondsPerGameSecond)
        //{
        //    //  Debug.Log("Game Ticker Running: Value = " + gameTicker);
        //    eventValue -= secondsPerGameSecond;
        //    eventTimer++;
        //    //           Debug.Log("event timer = " + eventTimer);
        //}

        if (eventValue >= 1)
        {
            //  Debug.Log("Game Ticker Running: Value = " + gameTicker);
            eventValue -= 1;
            eventTimer++;
            //           Debug.Log("event timer = " + eventTimer);
        }


        if (eventTimer < 51)
        {
            light.GetComponent<Light2D>().color = lightColour.Evaluate(eventTimer * 0.02f);
            //Debug.Log("testing: eventTimer = " + eventTimer + ". Color: " + light.GetComponent<Light2D>().color);
        }
        else
        {
            // Changing this to false will stop that the method from being called every frame
            Debug.Log("Sunset Function Finished");
            sunsetInitiated = false;
        }
    }

    private void CallSunriseMethod()
    {
        eventValue += Time.deltaTime;

        //if (eventValue >= secondsPerGameSecond)
        //{
        //    //  Debug.Log("Game Ticker Running: Value = " + gameTicker);
        //    eventValue -= secondsPerGameSecond;
        //    eventTimer--;
        //    //           Debug.Log("event timer = " + eventTimer);
        //}

        if (eventValue >= 1)
        {
            //  Debug.Log("Game Ticker Running: Value = " + gameTicker);
            eventValue -= 1;
            eventTimer--;
            //           Debug.Log("event timer = " + eventTimer);
        }


        if (eventTimer > 0)
        {
            light.GetComponent<Light2D>().color = lightColour.Evaluate(eventTimer * 0.02f);
            //Debug.Log("testing: eventTimer = " + eventTimer + ". Color: " + light.GetComponent<Light2D>().color);
        }
        else
        {
            // Changing this to false will stop that the method from being called every frame
            Debug.Log("Sunrise Function Finished");
            sunriseInitiated = false;
            //            eventTimer = 0;
        }
    }

    //private void eventTimerTicker()
    //{
    //    sunsetWindow += Time.deltaTime;

    //    if (sunsetWindow >= secondsPerGameSecond)
    //    {
    //        //  Debug.Log("Game Ticker Running: Value = " + gameTicker);

    //        sunsetWindow -= secondsPerGameSecond;

    //        eventTimer++;

    //        //           Debug.Log("event timer = " + eventTimer);
    //    }
    //}
}


