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
  public float gamePos = 5.35f;

  public enum headState { idle, kissMove, kissFinish, beginGame, headButt };
  public headState hS;
  private Transform transform;
  // Start is called before the first frame update
  void Start()
  {
    if (isLeft)
    {
      GetComponent<SpriteRenderer>().flipX = true;
      gamePos *= -1;
    }
    SetIsTalking(talking);
    transform = GetComponent<Transform>();
    hS = headState.headButt;
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
          if (isLeft && endPos < transform.position.x)
          {
            hS = headState.kissFinish;
          }
          if (!isLeft && endPos > transform.position.x)
          {
            hS = headState.kissFinish;
          }
          break;
        }
      case headState.headButt:
        {
          
          if (isLeft && endPos < transform.position.x +1)
          {
            transform.rotation = Quaternion.Euler(0, 0, -30);

            hS = headState.kissFinish;
          }
          else if (!isLeft && endPos > transform.position.x -1)
          {
            transform.rotation = Quaternion.Euler(0, 0, 30);

            hS = headState.kissFinish;
          }
          else
           MoveHead(moveSpeed);
          break;
        }
      case headState.beginGame:
        {
          MoveHead(moveSpeed);
          if (isLeft && gamePos < transform.position.x)
          {
            hS = headState.idle;
          }
          if (!isLeft && gamePos > transform.position.x)
          {
            hS = headState.idle;
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
    animator.SetBool("IsTalking", talk);
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
