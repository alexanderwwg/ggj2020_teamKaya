using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    public SineWaveScript sineWave;
    public TriangleWaveScript triangleWave;
    public SquareWaveScript squareWave;
    public float frequency;
    public float amplitude;
    public WaveType waveType;


    // Start is called before the first frame update
    void Start()
    {
        sineWave = GetComponent<SineWaveScript>();
        triangleWave = GetComponent<TriangleWaveScript>();
        squareWave = GetComponent<SquareWaveScript>();
        waveType = WaveType.sine;
        frequency = sineWave.frequency;
        amplitude = sineWave.amplitude;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void switchWave(WaveType waveType, float switchAmplitude, float switchFrequency)
    {

        switch(waveType)
        {
            case WaveType.sine:
            {
                waveType = WaveType.sine;
                sineWave.isOn = true;
                squareWave.isOn = false;
                triangleWave.isOn = false;

                sineWave.amplitude = switchAmplitude;
                sineWave.frequency = switchFrequency;
                sineWave.direction = 1;
                break;
            }

            case WaveType.square:
            {
                waveType = WaveType.square;
                sineWave.isOn = false;
                squareWave.isOn = true;
                triangleWave.isOn = false;
                squareWave.direction = -1;

                squareWave.amplitude = switchAmplitude;
                squareWave.frequency = switchFrequency;
                break;
            }
            case WaveType.triangle:
            {
                waveType = WaveType.triangle;
                sineWave.isOn = false;
                triangleWave.isOn = true;
                squareWave.isOn = false;
                triangleWave.direction = -1;

                triangleWave.amplitude = switchAmplitude;
                triangleWave.frequency = switchFrequency;
                break;
            }
            amplitude = switchAmplitude;
            frequency = switchFrequency;
        }
    }
    public void changeAttributes(float switchAmplitude, float switchFrequency, float switchDirection=-1)
        {
            switch(waveType)
            {
                case WaveType.triangle:
                {
                    triangleWave.amplitude = switchAmplitude;
                    triangleWave.frequency = switchFrequency;
                    break;
                }
                case WaveType.square:
                {
                    squareWave.amplitude = switchAmplitude;
                    squareWave.frequency = switchFrequency;
                    Debug.Log("We're a square!");
                    break;
                }
                case WaveType.sine:
                {
                    sineWave.amplitude = switchAmplitude;
                    sineWave.frequency = switchFrequency;
                    break;
                }
            }
        }
}
