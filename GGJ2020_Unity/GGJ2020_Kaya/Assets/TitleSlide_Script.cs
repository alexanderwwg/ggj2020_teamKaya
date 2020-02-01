using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSlide_Script : MonoBehaviour
{
    public Vector2 finalPos;
    public float moveSpeed;

    private RectTransform transform;
    private bool moving;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<RectTransform>();
        moving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > finalPos.y)
        {
            Vector3 newPos = transform.position;
            newPos += Vector3.down * moveSpeed;
            transform.position = newPos;
            //transform.Translate((Vector3.down * Time.deltaTime) * moveSpeed);
        }
        else
        {
            moving = false;
        }
        
    }
}
