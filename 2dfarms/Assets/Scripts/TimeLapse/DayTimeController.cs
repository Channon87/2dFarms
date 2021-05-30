using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;

public class DayTimeController : MonoBehaviour
{
    const float secondsInDay = 86400f;
    const float phaseLength = 3600f;

    [SerializeField] Color nightLightColour;
    [SerializeField] AnimationCurve nightTimeCurve;
    [SerializeField] Color dayLightColor = Color.white;
   
    public static float time;
    [SerializeField] float timeScale = 60f;
    [SerializeField] float startAtTime = 28800f;
    [SerializeField] Text clock;
    [SerializeField] Text counter;
    [SerializeField] Light2D globalLight;
    private int days = 1;
    public float scale;
     List<TimeAgent> agents;

    private void Awake()
    {
        agents = new List<TimeAgent>();
    }
    private void Start()
    {
        time = startAtTime;
        scale = timeScale;
    }
    public void Subscribe(TimeAgent timeAgent)
    {
        agents.Add(timeAgent);
    }
    public void Unsubscribe(TimeAgent timeAgent)
    {
        agents.Remove(timeAgent);
    }

    float Hours
    {
        get
        {
            return time / 3600f;
        }
    }
    float Minutes
    {
        get
        {
            return time % 3600f / 60f;
        }
    }

    private void Update()
    {
        time += Time.deltaTime * timeScale;
        TimeValueCalculator();
        DayLight();
        counter.text = "Day " + days;
        if (time > secondsInDay) { NextDay(); }

        TimeAgents();
    }



    private void TimeValueCalculator()
    {
        int hh = (int)Hours;
        int mm = (int)Minutes;
        clock.text = hh.ToString("00") + ":" + mm.ToString("00");

    }

    private void DayLight()
    {
        float v = nightTimeCurve.Evaluate(Hours);
        Color c = Color.Lerp(dayLightColor, nightLightColour, v);
        globalLight.color = c;
    }

    int oldPhase = 0;
    private void TimeAgents()
    {
        int currentPhase = (int)(time / phaseLength);

        if (oldPhase != currentPhase)
        {
            oldPhase = currentPhase;
            for (int i = 0; i < agents.Count; i++)
            {
                agents[i].Invoke();
            }
        }
    }

    private void NextDay()
    {
        time = 0;
        days += 1;
    }
    public void TwoSpeed()
    {
        
        timeScale = scale * 2;
    }
    public void TenSpeed()
    {
        timeScale = scale * 10;
    }
    public void Normal()
    {
        timeScale = scale;
    }
}

