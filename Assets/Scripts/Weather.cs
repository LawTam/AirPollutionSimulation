using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SimpleJSON;
using TMPro;
using Random = UnityEngine.Random;

public class Weather : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI myWeatherLabel;
    public ParticleSystem upperFog;
    public ParticleSystem buttomFog;
    public ParticleSystem.VelocityOverLifetimeModule upperFogData;
    public ParticleSystem.VelocityOverLifetimeModule buttomFogData;
    public ParticleSystem.EmissionModule upperAirDensity;
    public ParticleSystem.EmissionModule buttomAirDensity;
    
    public float day;
    public string windSpeed;
    public float windSpeedFloat;
    
    public string windDegree;
    public float windDegreeFloat;
    
    public string cloudDensity;
    public float cloudDensityFloat;
    
    public string cloudType;

    public float finalTemp;

    private float direction = 1.0f;
    void Start()
    {
        upperFogData = upperFog.GetComponent<ParticleSystem>().velocityOverLifetime;
        buttomFogData = buttomFog.GetComponent<ParticleSystem>().velocityOverLifetime;

        upperAirDensity = upperFog.GetComponent<ParticleSystem>().emission;
        buttomAirDensity = buttomFog.GetComponent<ParticleSystem>().emission;
        
        StartCoroutine(SendRequest());
    }
    
    IEnumerator SendRequest()
    {
        //get the current weather
        WWW request = new WWW("https://api.openweathermap.org/data/2.5/forecast?q=hongkong&appid=11512961460be369199c77ed4f430887"); //get our weather
        yield return request;
 
        if (request.error == null || request.error == "")
        { 
            var N = JSON.Parse(request.text);
           // Debug.Log(N["list"][0]["wind"]["speed"]);
            int tempDay = Convert.ToInt32(day);
            
            windSpeed = N["list"][tempDay]["wind"]["speed"];
            windDegree = N["list"][tempDay]["wind"]["deg"];
            cloudDensity = N["list"][tempDay]["clouds"]["all"];
            
            int tempCloud;
            Int32.TryParse(cloudDensity, out tempCloud);
            if (tempCloud <= 25 )
            {
                cloudType = "few clouds";
            } else if (tempCloud <= 50)
            {
                cloudType = "scattered clouds";
            } else if (tempCloud <= 84)
            {
                cloudType = "broken clouds";
            }
            else
            {
                cloudType = "overcast clouds";
            }

            string temp = N["list"][tempDay]["main"]["temp"].Value;
            float tempTemp; 
            float.TryParse(temp, out tempTemp); 
            finalTemp = Mathf.Round((tempTemp - 273.0f)*10)/10;

            float.TryParse(windSpeed, out windSpeedFloat);
            float.TryParse(windDegree, out windDegreeFloat);
            float.TryParse(cloudDensity, out cloudDensityFloat);

            if (windDegreeFloat > 180.0f)
            {
                direction = -1.0f;
            }
            else
            {
                direction = 1.0f;
            }
            
            windSpeedFloat = windSpeedFloat * direction * -1.0f;
            windDegreeFloat = windDegreeFloat * (float)Math.PI / 180 * direction;
        }
        else
        {
            Debug.Log("WWW error: " + request.error);
        }
    }

    public void updateDays(float newDay)
    {
        day = newDay;
        StartCoroutine(SendRequest());
    }

    // Update is called once per frame
    void Update()
    {
        myWeatherLabel.text =
            "Hong Kong Day: " + Convert.ToInt32(day)
                              + "\nWind Speed: " + windSpeed
                              + "\nWind degree: " + windDegree + " degree"
                              + "\nCloud density: " + cloudDensity + "% " + cloudType
                              + "\nTemperature: " + finalTemp + " celsius";

        upperFogData.x = windSpeedFloat/4.0f;
        upperFogData.y = windDegreeFloat/4.0f;

        buttomFogData.x = windSpeedFloat / 8.0f;
        buttomFogData.y = windDegreeFloat / 8.0f;

        upperAirDensity.rateOverTime = cloudDensityFloat;
        buttomAirDensity.rateOverTime = cloudDensityFloat;

        upperAirDensity.rateOverTime = 100;
        buttomAirDensity.rateOverTime = 100;
    }
}
