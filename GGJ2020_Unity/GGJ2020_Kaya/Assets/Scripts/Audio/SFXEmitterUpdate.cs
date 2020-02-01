using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class SFXEmitterUpdate : MonoBehaviour
{
    // Per Second.
    public float updateRate = 0.25f;
    [Range(0, 1)]
    float progressValue;

    StudioEventEmitter sfxEmitter;


    public void UpdateProgress(float input)
    {
        progressValue = Mathf.Clamp(input, 0, 1);
        sfxEmitter.SetParameter("Progress", progressValue);
    }

    private void Start()
    {
        sfxEmitter = gameObject.GetComponent<StudioEventEmitter>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            UpdateParameters(true);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            UpdateParameters(false);
        }
        print(progressValue);


    }

    void UpdateParameters(bool increase)
    {
        if (increase)
        {
            UpdateProgress(progressValue + updateRate * Time.deltaTime);
        }
        else
        {
            UpdateProgress(progressValue - updateRate * Time.deltaTime);
        }
    }


}
