using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSlide_Script : MonoBehaviour
{
    public Vector2 finalPos;
    public float moveSpeed;

    private RectTransform rectransform;
    private bool moving;
    // Start is called before the first frame update
    void Start()
    {
        rectransform = GetComponent<RectTransform>();
        moving = true;
    }

    // Update is called once per frame
    void Update()
    {
    print(rectransform.position.y + " " + finalPos.y);
        if(rectransform.position.y > finalPos.y)
        {
            Vector3 newPos = rectransform.position;
            newPos += Vector3.down * moveSpeed *Time.deltaTime;
            rectransform.position = newPos;
            //transform.Translate((Vector3.down * Time.deltaTime) * moveSpeed);
        }
        else
        {
            moving = false;
        }
        
    }
}
