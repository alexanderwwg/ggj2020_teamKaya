using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public GameObject SpeakingLine;
    public GameObject ListeningLine;
    public SineWaveScript SpeakingScript;
    public SineWaveScript ListeningScript;
    public float amplitudeMargin=0.2f;
    public float frequencyMargin=0.2f;
    public float offsetMargin=0.1f;
    //private float offset;

    // Start is called before the first frame update
    void Start()
    {
        SpeakingScript = SpeakingLine.GetComponent<SineWaveScript>();
        ListeningScript = ListeningLine.GetComponent<SineWaveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float offset = ListeningScript.offset % 30;
        if(ListeningScript.amplitude >= SpeakingScript.amplitude-amplitudeMargin && ListeningScript.amplitude <= SpeakingScript.amplitude+amplitudeMargin)
        {
            if(ListeningScript.frequency >= SpeakingScript.frequency-frequencyMargin && ListeningScript.frequency <= SpeakingScript.frequency+frequencyMargin)
            {
                if(ListeningScript.offset >= SpeakingScript.offset-offsetMargin && ListeningScript.offset <= SpeakingScript.offset+offsetMargin)
                {
                    Debug.Log("You Win!");
                    ListeningLine.GetComponent<Renderer>().material.color = Color.green;
                }
            }
        }
    }
}
