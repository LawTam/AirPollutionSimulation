using UnityEngine;
using System.Collections;

// http://twiik.net/articles/simplest-possible-day-night-cycle-in-unity-5

public class DayNightController1 : MonoBehaviour
{

    public Light sun;
    public float secondsInFullDay = 120f;
    [Range(0, 1)]
    public float currentTimeOfDay = 0;
    [HideInInspector]
    public float timeMultiplier = 1f;
    public float intensity;
    float sunInitialIntensity;

    public float firstColor;
    public float secondColor;

    public GameObject[] Material;

    void Start()
    {
        // sunInitialIntensity = sun.intensity;
        sunInitialIntensity = 2;
        currentTimeOfDay = .5f;
    }

    void Update()
    {
        UpdateSun();

        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;

        if (currentTimeOfDay >= 1)
        {
            currentTimeOfDay = 0;
        }
        setSky();

        UpdateColors();
    }

    void UpdateColors()
    {
        for(int i = 0; i < Material.Length; i++)
        {
            Material[i].GetComponent<Renderer>().material.color = new Color (firstColor, secondColor, secondColor);
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
        intensity = sunInitialIntensity * intensityMultiplier;

    }

    void setSky()
  {
      if(currentTimeOfDay <= .5f)
      {
          RenderSettings.skybox.SetFloat("_Exposure", (2*currentTimeOfDay + .1f));
            for(int i = 0; i < Material.Length; i++)
            {
                firstColor = 2 * currentTimeOfDay;
                secondColor = 2 * currentTimeOfDay;
            }
      }
      else if (currentTimeOfDay > .5f)
      {
          RenderSettings.skybox.SetFloat("_Exposure", (2 - (2 * currentTimeOfDay) + .1f));
            firstColor = 2 - (2 * currentTimeOfDay);
            secondColor = 2 - (2 * currentTimeOfDay);
        }
  }
  

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
