using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Head_AniScript : MonoBehaviour
{
  public Animator animator;
  public bool talking;
  public bool isLeft;
  public float moveSpeed;
  public float endPos;
  public float gamePos = 5.35f;

  public enum HeadState { idle, kissMove, kissFinish, beginGame, headButt };
  public HeadState hS;

  public GameObject badFx, goodFx;

  public enum HeadType { dude, girl, asiangirl, duck};
  public HeadType type;

  public enum LoopType { slow, fast};
  public LoopType loopType;

  private StudioEventEmitter audioEventEmitter;
  string eventSetting = "";
  // Start is called before the first frame update
  void Start()
  {
    audioEventEmitter = GetComponent<StudioEventEmitter>();
    if (isLeft)
    {
      GetComponent<SpriteRenderer>().flipX = true;
      gamePos *= -1;
			endPos *= -1;
    }
    SetIsTalking(talking);
    hS = HeadState.beginGame;
  }

  // Update is called once per frame
  void Update()
  {
    switch (hS)
    {
      case HeadState.idle:
        {

          break;
        }


      case HeadState.kissMove:
        {
          MoveHead(moveSpeed);
          if (isLeft && endPos < transform.position.x)
          {
            hS = HeadState.kissFinish;
            Instantiate(goodFx, Vector3.zero, Quaternion.identity);
            AudioStatics.PlayOneShotAtLocation("event:/sfx_kiss_success", Vector3.zero);
          }
          if (!isLeft && endPos > transform.position.x)
          {
            hS = HeadState.kissFinish;
          }
          break;
        }
      case HeadState.headButt:
        {

		  
          if (isLeft && endPos < transform.position.x +1)
          {
			AudioStatics.PlayOneShotAtLocation("event:/sfx_kiss_fail", Vector3.zero);
            transform.rotation = Quaternion.Euler(0, 0, -30);

            hS = HeadState.kissFinish;
            Instantiate(badFx, Vector3.zero, Quaternion.identity);
            
          }
          else if (!isLeft && endPos > transform.position.x -1)
          {
            transform.rotation = Quaternion.Euler(0, 0, 30);

            hS = HeadState.kissFinish;
          }
          else
           MoveHead(moveSpeed);
          break;
        }
      case HeadState.beginGame:
        {
          MoveHead(moveSpeed);
          if (isLeft && gamePos < transform.position.x)
          {
            hS = HeadState.idle;
            //SetIsTalking(true);
          }
          if (!isLeft && gamePos > transform.position.x)
          {
            hS = HeadState.idle;
            //SetIsTalking(true);
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

    if(!talk)
    {
      if(eventSetting.Length > 0)
      {
        AudioStatics.StopEvent(audioEventEmitter);
      }


      return;
    }



    eventSetting = "event:/vo_char";

    switch(type)
    {
      case HeadType.dude:
        eventSetting += "2";
        break;
      case HeadType.girl:
        eventSetting += "1";
        break;
      case HeadType.asiangirl:
        eventSetting += "3";
        break;
      case HeadType.duck:
        eventSetting += "4";
        break;
    }
    eventSetting += loopType == 0 ? "_slow_loop" : "_fast_loop";

    audioEventEmitter.Event = eventSetting;

    

    AudioStatics.PlayEvent(audioEventEmitter);
    audioEventEmitter.SetParameter("Progress", 0);
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

  public void UpdateMatch(float newProgress)
  {
    audioEventEmitter.SetParameter("Progress", newProgress);
  }

  public void GoodJob()
  {
    SetIsTalking(false);

    eventSetting = "event:/vo_char";

    switch (type)
    {
      case HeadType.dude:
        eventSetting += "2";
        break;
      case HeadType.girl:
        eventSetting += "1";
        break;
      case HeadType.asiangirl:
        eventSetting += "3";
        break;
      case HeadType.duck:
        eventSetting += "4";
        break;
    }
    eventSetting +="_good";
    AudioStatics.PlayOneShotAtLocation(eventSetting, transform.position);
  }

}
