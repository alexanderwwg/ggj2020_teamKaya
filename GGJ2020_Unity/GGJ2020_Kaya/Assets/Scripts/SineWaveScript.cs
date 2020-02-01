using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineWaveScript : MonoBehaviour
{
    public int numberOfPoints = 200;
    [Range(0,100)]
    public float length = 30;
    [Range(0,10)]

    public float amplitude = 1;
    [Range(0,10)]

    public float frequency = 1;
    public float offset = 0;
    public int direction = 1;
    public bool isOn = false;

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
        if(isOn)
        {
        //creates the sine curve from the amplitude, frequency and offset
        var points = new Vector3[numberOfPoints];
        float step = length / numberOfPoints;
        var t = Time.time;
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = new Vector3(
                pos.x + i * step,
                pos.y + Mathf.Sin((i*step + t*direction + offset)*frequency) * amplitude,
                0.0f);
        }
        lineRenderer.SetPositions(points);
        }
    }
}
