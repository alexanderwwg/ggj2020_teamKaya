using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WaveType {sine, triangle, square}
public class LevelDataScript : MonoBehaviour
{
    public Wave[] Waves = new Wave[6];
    // Start is called before the first frame update
    void Start()
    {
        Waves = new Wave[9];
        Waves[0] = new Wave(2f, 0.5f,WaveType.sine);
        Waves[1] = new Wave(2f,2f,WaveType.sine);
        Waves[2] = new Wave(0.5f,3f,WaveType.sine); 

        Waves[3] = new Wave(1f,1f,WaveType.sine); 
        Waves[4] = new Wave(2f,4f,WaveType.sine); 
        Waves[5] = new Wave(0.5f,1f,WaveType.sine); 

        Waves[6] = new Wave(5f,1f,WaveType.sine); 
        Waves[7] = new Wave(0.5f,3f,WaveType.sine); 
        Waves[8] = new Wave(3f,2f,WaveType.sine); 
        Debug.Log("The number of waves is");
        Debug.Log(Waves);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public class Wave
{
    public float amplitude;
    public float frequency;
    public WaveType type;
    public Wave(float waveAmplitude, float waveFrequency, WaveType waveType)
    {
        amplitude = waveAmplitude;
        frequency = waveFrequency;
        type = waveType;
    }
}