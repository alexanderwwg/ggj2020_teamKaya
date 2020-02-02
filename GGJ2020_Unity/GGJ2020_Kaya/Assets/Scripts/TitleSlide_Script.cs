using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSlide_Script : MonoBehaviour
{
    public Vector2 finalPos;
    public float moveSpeed;
    public MenuButton_Script menuScript;

    private RectTransform rectransform;
    // Start is called before the first frame update
    void Start()
    {
        rectransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

        if(rectransform.position.y > finalPos.y)
        {
            Vector3 newPos = rectransform.position;
            newPos += Vector3.down * moveSpeed *Time.deltaTime;
            rectransform.position = newPos;
            //transform.Translate((Vector3.down * Time.deltaTime) * moveSpeed);
        }
        else
        {
            menuScript.ShowButtons();
        }
        
    }
}
