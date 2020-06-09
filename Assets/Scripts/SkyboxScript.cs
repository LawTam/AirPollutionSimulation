using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxScript : MonoBehaviour
{
    float rotator;
    public float fogDis;
    public float rot = 0;
    public Skybox sky;
    public float skyrottation;
    public ParticleSystem lowerSmog;
    public Transform smogTransformer;

    private void Start()
    {
        rotator = 0;
        
    }
    public float rotateSpeed = .5f;
    // Update is called once per frame
    void Update()
    {

        
        RenderSettings.skybox.SetFloat("_Rotation", skyrottation);
        skyrottation -= (rotateSpeed / 4f);
        rotator -= rotateSpeed;

       // smogChanger();

      
    }

    void smogChanger()
    {
        fogDis = RenderSettings.fogEndDistance;
        if (fogDis >= 2000)
        {
            RenderSettings.fogEndDistance += -4f;
        }
    }
}
