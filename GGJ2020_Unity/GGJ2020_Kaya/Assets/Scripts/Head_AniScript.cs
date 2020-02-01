using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head_AniScript : MonoBehaviour
{
    public Animator animator;
    public bool talking;
    public bool isLeft;
    public float moveSpeed;
    public float endPos;

    enum headState {idle, kissMove, kissFinish };
    private headState hS;
    private Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        SetIsTalking(talking);
        transform = GetComponent<Transform>();
        hS = headState.idle;
    }

    // Update is called once per frame
    void Update()
    {
        switch (hS)
        {
            case headState.idle:
                {
                    break;
                }
            case headState.kissMove:
                {
                    MoveHead(moveSpeed);
                    if(isLeft && endPos < transform.position.x)
                    {
                        hS = headState.kissFinish;
                    }
                    if(!isLeft && endPos > transform.position.x)
                    {
                        hS = headState.kissFinish;
                    }
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    public void SetIsTalking(bool talk)
    {
        animator.SetBool("IsTalking",talk);
    }

    public void MoveHead(float speed)
    {
        if (isLeft)
        {
            transform.Translate((Vector3.right * Time.deltaTime) * moveSpeed);
        }
        else
        {
            transform.Translate((Vector3.left * Time.deltaTime) * moveSpeed);
        }
        
    }

}
