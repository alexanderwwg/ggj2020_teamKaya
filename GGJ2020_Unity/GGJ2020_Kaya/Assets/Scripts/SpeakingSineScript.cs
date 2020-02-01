using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakingSineScript : MonoBehaviour
{
    public int numberOfPoints = 200;
    public float length = 10;
    public float amplitude = 1;
    public float tolerance = 0.1f;
    public float frequency = 1;

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
        //numberOfPoints = numberOfPoints ==0 ? (int)length*2 : (int)length*numberOfPoints;
        //lineRenderer.positionCount = numberOfPoints;
        var points = new Vector3[numberOfPoints];
        float step = length / numberOfPoints;
        var t = Time.time;
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = new Vector3(pos.x + i * step/frequency, pos.y + Mathf.Sin(i*step + t) * amplitude, 0.0f);
        }
        lineRenderer.SetPositions(points);
    }
    
}
