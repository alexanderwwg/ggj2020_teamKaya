using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleWaveScript : MonoBehaviour
{
    public int numberOfPoints = 10;
    public float length = 30;
    public float amplitude = 1;
    public float frequency = 1;
    public float offset = 0;

    private LineRenderer lineRenderer;
    private Vector3 pos;
    private List<Vector3> points = new List<Vector3>(); // Generated points before Simplify is used.

    public void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.widthMultiplier = 0.2f;
        lineRenderer.positionCount = (int)(numberOfPoints/(frequency)+1);
        pos = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.positionCount = (int)(numberOfPoints/(frequency)+1);
        //creates the sine curve from the amplitude, frequency and offset
        var points = new Vector3[(int)(numberOfPoints/(frequency)+1)];
        float step = frequency;
        var t = Time.time;
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = new Vector3(
                pos.x + i * step/2,
                pos.y + Mathf.PingPong(i*-amplitude, amplitude),
                0.0f);
            points[i] = new Vector3(
                pos.x + i * step,
                pos.y + Mathf.PingPong(i*-amplitude, amplitude),
                0.0f);
        }
        lineRenderer.SetPositions(points);
    }
}
