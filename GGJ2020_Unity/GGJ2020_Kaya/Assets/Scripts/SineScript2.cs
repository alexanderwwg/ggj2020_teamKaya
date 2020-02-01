using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineScript2 : MonoBehaviour
{
    public int numberOfPoints = 200;
    public float length = 30;
    public float masterAmplitude = 1;
    public float amplitude = 1;
    public float frequency = 1;
    public float offset = 0;
    public float amplitude2 = 1;

    public float frequency2 = 2;
    
    public float offset2 = 3;
    public bool isBreathing = false;

    private LineRenderer lineRenderer;
    private Vector3 pos;
    private List<Vector3> points = new List<Vector3>(); // Generated points before Simplify is used.

    public void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.widthMultiplier = 0.2f;
        lineRenderer.positionCount = numberOfPoints;
        pos = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        //creates the sine curve from the amplitude, frequency and offset
        var points = new Vector3[numberOfPoints];
        float step = length / numberOfPoints;
        var t = Time.time;
        float height;

        //makes the entire sine curve increase in height and decrease over time
        if(isBreathing)
            {
                height =  Mathf.Sin(Mathf.PingPong(t, 3))* masterAmplitude;
            }
            else
            {
                height = masterAmplitude;
            }

        for (int i = 0; i < numberOfPoints; i++)
        {
            float sine1 = Mathf.Sin((i*step + t + offset)*frequency) * amplitude * height;
            float sine2 = Mathf.Sin((i*step + t + offset2)*frequency2) * amplitude2 * height;

            points[i] = new Vector3(
                pos.x + i * step,
                //adds two sine curves
                pos.y + sine1+sine2,
                0.0f);
        }
        lineRenderer.SetPositions(points);
    }
}
