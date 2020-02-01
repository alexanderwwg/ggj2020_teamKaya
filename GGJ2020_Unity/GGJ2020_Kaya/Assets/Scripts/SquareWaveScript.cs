using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareWaveScript : MonoBehaviour
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
        numberOfPoints = (int)(length/(1/frequency)*2);
        lineRenderer.positionCount = numberOfPoints;
        pos = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        if(isOn)
        {
            numberOfPoints = (int)(length/(1/frequency)*2);
            lineRenderer.positionCount = numberOfPoints;
            //creates the sine curve from the amplitude, frequency and offset
            var points = new Vector3[(int)(length/(1/frequency)*2)];
            float step = (length/(numberOfPoints/2));
            var t = Time.time;
            // points[0] = new Vector3(pos.x, pos.y -amplitude, 0.0f);
            for (int i = 0; i < numberOfPoints; i+=2)
            {
                Debug.Log(t%2);

                if(((i)/2)%2 == 0)
                {
                points[i] = new Vector3(
                    pos.x + i * step+(t*direction/2)%frequency*4,
                    pos.y +amplitude * -1,
                    0.0f);
                points[i+1] = new Vector3(
                    pos.x + i * step+(t*direction/2)%frequency*4,
                    pos.y -amplitude * -1,
                    0.0f);

                }
                else
                {
                    points[i] = new Vector3(
                    pos.x + i * step + offset+(t*direction/2)%frequency*4,
                    pos.y -amplitude * -1,
                    0.0f);
                    points[i+1] = new Vector3(
                        pos.x + i * step + offset+(t*direction/2)%frequency*4,
                        pos.y +amplitude * -1,
                        0.0f);
                }
            }
        lineRenderer.SetPositions(points);
        }
    }
}
