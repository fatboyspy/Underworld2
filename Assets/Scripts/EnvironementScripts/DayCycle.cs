using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Light))]
[RequireComponent(typeof(LensFlare))]
public class DayCycle : MonoBehaviour
{
    public Transform sun;
    public float minutesInDay;
    public float secondsInDay;

    public float sunRise;
    public float sunSet;
    public float blendModidfier;
    public SunState sunState = SunState.Idle;

    const float SECOND = 1;
    const float MINUTE = SECOND*60;
    const float HOUR = MINUTE * 60;
    const float DAY = HOUR * 24;

    public const float DEGREES_PER_SECOND = 360 / DAY;
    public float timeOfDay;
    public float degreeRotation;
    float degreeString = 0;
    void Start()
    {
        sun = this.transform;
        timeOfDay = 0;
        minutesInDay = 5;
        secondsInDay = minutesInDay * MINUTE;
        RenderSettings.skybox.SetFloat("_Blend",0);
        degreeRotation = DEGREES_PER_SECOND*DAY /(minutesInDay*MINUTE);
        sunRise = 0.35f;
        sunSet = 0.65f;
        blendModidfier = 4;
        sunRise *= secondsInDay;
        sunSet *= secondsInDay;
    }

    void Update()
    {
        sun.Rotate(new Vector3(degreeRotation,0,0) * Time.deltaTime);
        timeOfDay += Time.deltaTime;
        if (timeOfDay > secondsInDay)
            timeOfDay -= secondsInDay;
        if (timeOfDay > sunRise && timeOfDay < sunSet && RenderSettings.skybox.GetFloat("_Blend") < 1)
        {
            sunState = SunState.SunSet;
            SkyboxBlend();
        }
        else if (timeOfDay > sunSet && RenderSettings.skybox.GetFloat("_Blend") > 0)
        {
            sunState = SunState.SunRise;
            SkyboxBlend();
        }
        else
            sunState = SunState.Idle;
    }
    void SkyboxBlend()
    {
        float blendValue=0;
        switch (sunState)
        {
            case SunState.SunSet:
                blendValue = (timeOfDay - sunRise) / secondsInDay * blendModidfier;
                break;
            case SunState.SunRise:
                blendValue =1-((timeOfDay - sunSet) / secondsInDay * blendModidfier);
                break;
        }
        RenderSettings.skybox.SetFloat("_Blend", blendValue);
    }
}
public enum SunState
{
    Idle,
    SunRise,
    SunSet
}