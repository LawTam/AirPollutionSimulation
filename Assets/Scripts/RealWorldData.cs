using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RealWorldData : MonoBehaviour
{

    public ParticleSystem lowerParticles;
    public ParticleSystem upperParticles;
    public ParticleSystem.VelocityOverLifetimeModule upperFogData;
    public ParticleSystem.VelocityOverLifetimeModule buttomFogData;
    public ParticleSystem.EmissionModule upperAirDensity;
    public ParticleSystem.EmissionModule buttomAirDensity;

    bool initialValue;
    public float EndDistance;
    public float StartDistance;
    public float smogDis;

    string setmonth;
    string[] month;

    string loading;
    public float near;
    public float far;

    public float year;

    float day;
    float []data;
    public TextMeshProUGUI myWeatherLabel;
    // Start is called before the first frame update
    void Start()
    {

        upperFogData = upperParticles.GetComponent<ParticleSystem>().velocityOverLifetime;
        buttomFogData = lowerParticles.GetComponent<ParticleSystem>().velocityOverLifetime;

        upperAirDensity = upperParticles.GetComponent<ParticleSystem>().emission;
        buttomAirDensity = lowerParticles.GetComponent<ParticleSystem>().emission;


        loading = "loading simulation...";
        setmonth = "January";
        year = 2014;
        EndDistance = 12000 - (100 * 105);
        StartDistance = 0 - (10 * 105);
        day = 71;
        //updateParticles(0);
        month = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
       // month = new string[] { "December" , "November", "October", "September", "August", "July", "June", "May", "April", "March", "February", "January", };
        data = new float[] { 87, 89, 87, 58, 62, 67, 74, 64, 52, 99, 73, 73, 85, 79, 83, 52, 59, 70, 81, 65, 58, 80, 93, 82, 67, 87, 97, 56, 52, 77, 69, 81, 52, 81, 92, 94, 73, 77, 94, 66, 57, 66, 89, 77, 59, 65, 77, 96, 95, 79, 82, 85, 63, 81, 80, 68, 54, 76, 132, 102, 113, 112, 106, 96, 77, 69, 102, 98, 75, 105, 113, 105 };
    }

    private void Update()
    {
        myWeatherLabel.text =
            "Hong Kong Year and Month: " + year + " " + setmonth
             + "\nAir Quality Index: " + data[(int)day]
             + "\n" + loading;

        if (RenderSettings.fogEndDistance < EndDistance)
        {
            RenderSettings.fogEndDistance += 20;
        }
        else if (RenderSettings.fogEndDistance >= EndDistance)
        {
            RenderSettings.fogEndDistance -= 20;
        }

        if (RenderSettings.fogStartDistance < StartDistance)
        {
            RenderSettings.fogStartDistance += 20;
        }
        else if (RenderSettings.fogStartDistance >= StartDistance)
        {
            RenderSettings.fogStartDistance -= 20;
        }

        if (RenderSettings.fogStartDistance >= (StartDistance - 20f) && RenderSettings.fogStartDistance <= (StartDistance + 20f) && RenderSettings.fogEndDistance >= (EndDistance - 20) && RenderSettings.fogEndDistance <= (EndDistance + 20))
            loading = " ";
        else
            loading = "loading simulation...";

        near = RenderSettings.fogStartDistance;
        far = RenderSettings.fogEndDistance;

        if(initialValue == false)
        {
            initialValue = true;
            updateParticles(0);
        }
    }

    public void smogPerMonth(float month)
    {
        //EndDistance = 10500 - (100 * data[(int)month]);
        //StartDistance = 0 - (10 * data[(int)month]);
        day = 71 - month;
        EndDistance = 12000 - (100 * data[(int)(71 - month)]);
        StartDistance = 0 - (10 * data[(int)(71 - month)]);

        updateParticles(month);
    }

    public void updateDays(float newDay)
    {
        //year = 2019 - (int)(newDay / 12);
        year = 2014 + (int)(newDay / 12);
        setMonth(newDay);
    }

    void setMonth(float x)
    {
        setmonth = month[(int)(x % 12)];
    }

    void updateParticles(float month)
    {

        upperFogData.x = -2;
        upperFogData.y = -2;

        buttomFogData.x = -1;
        buttomFogData.y = -1;

        var main = lowerParticles.main;
        main.maxParticles = 2 * Mathf.RoundToInt(15* data[(int)(71 - month)]);
        var main2 = upperParticles.main;
        main2.maxParticles = 2 * Mathf.RoundToInt(10 * data[(int)(71 - month)]);

        upperAirDensity.rateOverTime = data[(int)(71 - month)];
        buttomAirDensity.rateOverTime = data[(int)(71 - month)];
    }
    
}
