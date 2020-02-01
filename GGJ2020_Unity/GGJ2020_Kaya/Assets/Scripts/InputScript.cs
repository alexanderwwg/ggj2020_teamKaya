using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputScript : MonoBehaviour
{
    public GameObject listenLine;
    public SineWaveScript sineScript;
    public float amplitudeSpeed = 1f;
    public float frequencySpeed = 0.5f;
    public float offsetSpeed = 1f;
    public float frequencyFactor = 0.125f;
    public float amplitudeFactor = 3f;
    public float startDelay = 5.0f;
    private float startTime;

    public bool isOn= false;
    // Start is called before the first frame update
    void Start()
    {
        sineScript = listenLine.GetComponent<SineWaveScript>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(isOn)
        {
            float finalX = WithinRange(Input.mousePosition.x, 0, Screen.width);
            float finalY = WithinRange(Input.mousePosition.y, 0, Screen.height);
            sineScript.frequency = 1/(finalX/(Screen.width/2) * frequencyFactor);
            sineScript.amplitude = finalY/(Screen.height/2) * amplitudeFactor;
            //InputSCript.mousePosition.y
            //Debug.Log(sineScript.frequency);
            //Debug.Log(sineScript.amplitude);

            sineScript.frequency +=Input.GetAxis("Horizontal") * Time.deltaTime * frequencySpeed;
            sineScript.amplitude +=Input.GetAxis("Vertical") * Time.deltaTime * amplitudeSpeed;
            if (Input.GetKey(KeyCode.A))
            {
                sineScript.offset +=1*Time.deltaTime * offsetSpeed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                sineScript.offset -=1*Time.deltaTime *offsetSpeed;
            }
        }
        else
        {
            if (Time.time - startTime > startDelay)
            {
                isOn = true;
            }
        }
    }

    float Max(float a, float b)
    {
        return a>b ? a : b;
    }
    float Min(float a, float b)
    {
        return a<b ? a : b;
    }
    float WithinRange(float a, float low, float high)
    {
        if (a < low)
        {
            return low;
        }
        else if (a > high)
        {
            return high;
        }
        else
        {
            return a;
        }

    }
}
