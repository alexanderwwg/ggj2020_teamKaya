using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveControllerScript : MonoBehaviour
{
    public float closeness;
    private SineWaveScript sineWave;
    private SquareWaveScript squareWave;
    private TriangleWaveScript triangleWave;
    // Start is called before the first frame update
    void Start()
    {
        sineWave = GetComponent<SineWaveScript>();
        squareWave = GetComponent<SquareWaveScript>();
        triangleWave = GetComponent<TriangleWaveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
