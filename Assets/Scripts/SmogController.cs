using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmogController : MonoBehaviour
{

    public RealWorldData dates;

    public float EndDistance;
    public float StartDistance;
    public float smogDis;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(RenderSettings.fogEndDistance < EndDistance)
        {
            RenderSettings.fogEndDistance += 5;
        }
        else if (RenderSettings.fogEndDistance >= EndDistance)
        {
            RenderSettings.fogEndDistance -= 5;
        }

        if (RenderSettings.fogStartDistance < StartDistance)
        {
            RenderSettings.fogStartDistance += 5;
        }
        else if (RenderSettings.fogStartDistance >= StartDistance)
        {
            RenderSettings.fogStartDistance -= 5;
        }
        //RenderSettings.fogEndDistance = 10500 - (100 * smogIntensity * 2);
        //RenderSettings.fogStartDistance = 0 - (10 * smogIntensity * 1.5f);
    }


}
