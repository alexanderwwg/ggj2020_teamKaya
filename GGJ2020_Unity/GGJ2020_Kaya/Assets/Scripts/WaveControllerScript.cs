using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveControllerScript : MonoBehaviour
{
    public float closeness;
    private SineWaveScript speakingSine;
    private SquareWaveScript speakingSquare;
    private TriangleWaveScript speakingTriangle;

    private SineWaveScript listeningSine;
    private SquareWaveScript listeningSquare;
    private TriangleWaveScript listeningTriangle;
    public float winMargin;
    public GameObject speaking;
    public GameObject listening;
    public float amplitudeDifference;
    public float frequencyDifference;
    // Start is called before the first frame update
    void Start()
    {
        speakingSine = speaking.GetComponent<SineWaveScript>();
        speakingSquare = speaking.GetComponent<SquareWaveScript>();
        speakingTriangle = speaking.GetComponent<TriangleWaveScript>();
        listeningSine = listening.GetComponent<SineWaveScript>();
        listeningSquare = listening.GetComponent<SquareWaveScript>();
        listeningTriangle = listening.GetComponent<TriangleWaveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(speakingSine.isOn)
        {
            /*if (listeningSine.amplitude > speakingSine.amplitude)
            {
                amplitudeDifference = 1-listeningSine.amplitude/speakingSine.amplitude;
            }
            else
            {
                amplitudeDifference = (listeningSine.amplitude)/speakingSine.amplitude;
            }

            if (listeningSine.frequency > speakingSine.frequency)
            {
                frequencyDifference = 1-listeningSine.frequency/speakingSine.frequency;
            }
            else
            {
                frequencyDifference = (listeningSine.frequency)/speakingSine.frequency;
            }*/

            amplitudeDifference = Mathf.Clamp(Mathf.Abs(listeningSine.amplitude-speakingSine.amplitude), 0, 1);
            frequencyDifference = Mathf.Clamp(Mathf.Abs(listeningSine.frequency-speakingSine.frequency), 0, 1);
            
        }
        else if (speakingTriangle.isOn)
        {
            amplitudeDifference = Mathf.Clamp(Mathf.Abs(listeningTriangle.amplitude-speakingTriangle.amplitude), 0, 1);
            frequencyDifference = Mathf.Clamp(Mathf.Abs(listeningTriangle.frequency-speakingTriangle.frequency), 0, 1);
        }
        else
        {
            amplitudeDifference = Mathf.Clamp(Mathf.Abs(listeningSquare.amplitude-speakingSquare.amplitude), 0, 1);
            frequencyDifference = Mathf.Clamp(Mathf.Abs(listeningSquare.frequency-speakingSquare.frequency), 0, 1);
        }
        closeness = 1-(amplitudeDifference + frequencyDifference)/2;
        if (closeness > winMargin)
        {
            Debug.Log(closeness + " " + winMargin);
            GameStateScript.State = Game.matched;
            
        }
    }
}
