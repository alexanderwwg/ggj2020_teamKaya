using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    public SineWaveScript sineWave;
    public TriangleWaveScript triangleWave;
    public SquareWaveScript squareWave;


    // Start is called before the first frame update
    void Start()
    {
        sineWave = GetComponent<SineWaveScript>();
        triangleWave = GetComponent<TriangleWaveScript>();
        squareWave = GetComponent<SquareWaveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void switchWave(WaveType waveType, float amplitude, float frequency)
    {
        Debug.Log("We got here");

        switch(waveType)
        {
            case WaveType.sine:
            {
                Debug.Log(amplitude+" " + frequency);
                sineWave.isOn = true;
                squareWave.isOn = false;
                triangleWave.isOn = false;

                sineWave.amplitude = amplitude;
                sineWave.frequency = frequency;
                break;
            }

            case WaveType.square:
            {
                sineWave.isOn = false;
                squareWave.isOn = true;
                triangleWave.isOn = false;
                triangleWave.amplitude = amplitude;
                triangleWave.frequency = frequency;
                break;
            }
            case WaveType.triangle:
            {
                sineWave.isOn = false;
                squareWave.isOn = false;
                triangleWave.isOn = true;
                squareWave.amplitude = amplitude;
                squareWave.frequency = frequency;
                break;
            }
        }
    }
}
