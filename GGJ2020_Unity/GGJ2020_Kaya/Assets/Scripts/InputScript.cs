using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputScript : MonoBehaviour
{
    public GameObject listenLine;
    public SineWaveScript listenerSineScript;
    public GameObject Speaker;
    public GameObject Listener;
    public float amplitudeSpeed = 1f;
    public float frequencySpeed = 0.5f;
    public float offsetSpeed = 1f;
    public float frequencyFactor = 0.125f;
    public float amplitudeFactor = 3f;
    public float startDelay = 3;
    public float startTime;

    public bool isOn= false;
    // Start is called before the first frame update
    void Start()
    {
        listenerSineScript = Listener.GetComponent<SineWaveScript>();
        startTime = Time.time;
        Speaker.GetComponent<Renderer>().enabled = false;
        Listener.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isOn)
        {
            float finalX = WithinRange(Input.mousePosition.x, 0, Screen.width);
            float finalY = WithinRange(Input.mousePosition.y, 0, Screen.height);
            listenerSineScript.frequency = 1/(finalX/(Screen.width/2) * frequencyFactor);
            listenerSineScript.amplitude = finalY/(Screen.height/2) * amplitudeFactor;
            //InputSCript.mousePosition.y
            // Debug.Log(listenerSineScript.frequency);
            // Debug.Log(listenerSineScript.amplitude);

            listenerSineScript.frequency +=Input.GetAxis("Horizontal") * Time.deltaTime * frequencySpeed;
            listenerSineScript.amplitude +=Input.GetAxis("Vertical") * Time.deltaTime * amplitudeSpeed;
            Debug.Log("We are on!");
        }
        else
        {
            Debug.Log("check if timehas elapsed");
            if (Time.time - startTime > startDelay)
            {
                isOn = true;
                Speaker.GetComponent<Renderer>().enabled = true;
                Listener.GetComponent<Renderer>().enabled = true;
                GameStateScript.State = Game.game;
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
