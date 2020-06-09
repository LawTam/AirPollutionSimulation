using UnityEngine;
using System.Collections;

// http://twiik.net/articles/simplest-possible-day-night-cycle-in-unity-5

public class DayNightController : MonoBehaviour
{
    public GameObject [] backgroundBillboards;
    public Light sun;
    public float secondsInFullDay = 120f;
    [Range(0, 1)]
    public float currentTimeOfDay = 0;
    [HideInInspector]
    public float timeMultiplier = 1f;
    public Material skybox;
    Color color;

    float sunInitialIntensity;

    void Start()
    {
       
    }

    void Update()
    {
        UpdateSun();

        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;

        if (currentTimeOfDay >= 1)
        {
            currentTimeOfDay = 0;
        }
    }

    void UpdateSun()
    {
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);

        float intensityMultiplier = 1;
        if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f)
        {
            intensityMultiplier = 0;
        }
        else if (currentTimeOfDay <= 0.25f)
        {
            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
        }
        else if (currentTimeOfDay >= 0.73f)
        {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));
        }

        sun.intensity = sunInitialIntensity * intensityMultiplier;

       // setSky();
    }

    /*void setSky()
    {
        if(currentTimeOfDay <= .5f)
        {
            RenderSettings.skybox.SetFloat("_Exposure", (2*currentTimeOfDay + .1f));
        }
        else if (currentTimeOfDay > .5f)
        {
            RenderSettings.skybox.SetFloat("_Exposure", (2 - (2 * currentTimeOfDay) + .1f));
        }
    }
    */
    public void setCurrentTimeOfDay()
    {
        if (currentTimeOfDay >= .75f)
        {
            currentTimeOfDay = .35f;

        }
        else if (currentTimeOfDay >= .5f && currentTimeOfDay < .75f)
        {
            currentTimeOfDay = 0;
        }
        else if (currentTimeOfDay <= .25)
            currentTimeOfDay = .35f;
        else if (currentTimeOfDay > .25f && currentTimeOfDay < .5f)
            currentTimeOfDay = 0f;
    }
    
}
