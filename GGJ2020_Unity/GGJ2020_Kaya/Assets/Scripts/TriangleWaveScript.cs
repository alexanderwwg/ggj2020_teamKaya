using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleWaveScript : MonoBehaviour
{
    public int numberOfPoints = 10;
    [Range(0,100)]

    public float length = 30;
    [Range(0,10)]

    public float amplitude = 1;
    [Range(0,10)]

    public float frequency = 1;
    public float offset = 0;
    public float direction = 1;
    public bool isOn = false;
    private LineRenderer lineRenderer;
    private Vector3 pos;
    private List<Vector3> points = new List<Vector3>(); // Generated points before Simplify is used.

    public void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.widthMultiplier = 0.2f;
        numberOfPoints = (int)(length/(frequency)+1);
        lineRenderer.positionCount = numberOfPoints;
        pos = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn)
        {
            numberOfPoints = (int)(length/(frequency)+1);
            lineRenderer.positionCount = numberOfPoints;
            //creates the triangle wave from the amplitude, frequency and offset
            var points = new Vector3[(int)(length/(frequency)+1)];
            float step = frequency;
            var t = Time.time;
            for (int i = 0; i < numberOfPoints; i++)
            {
                Debug.Log(t%2);
                points[i] = new Vector3(
                    pos.x + i * step+(t*direction)%frequency*2+offset,
                    pos.y + Mathf.PingPong(i*-amplitude, amplitude)*2-amplitude,
                    0.0f);
            }
            lineRenderer.SetPositions(points);
        }
    }
}
