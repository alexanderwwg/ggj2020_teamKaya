using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginSpeakingScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float gamePos = -5.0f;
    public float moveSpeed = 0.1f;    private Transform transform;
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        while (transform.position.x < gamePos)
        {
            transform.Translate((Vector3.right * Time.deltaTime) * moveSpeed);
        }
    }
}
