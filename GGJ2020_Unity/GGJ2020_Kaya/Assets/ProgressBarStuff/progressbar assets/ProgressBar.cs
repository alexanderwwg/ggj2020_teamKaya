using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
  [Tooltip("Controls the length of the progress bar")]
  [Range(0, 1)]
  public float progress = 0.5f;

  private float hiddenProgress = 0;

  public float progressLerpSpeed = 15;

  [Header("Milestones")]
  [Range(0, 1)]
  public float checkPoint1 = 0;
  [Range(0, 1)]
  public float checkPoint2 = 0;
  [Range(0, 1)]
  public float checkPoint3 = 0;


  // The image this script is attached to
  private Renderer rend;

  [Header("Component References")]
  public Transform[] checkpoints;
	[HideInInspector]
  public int starAmt = 0;


  public List<SpriteRenderer> starSpriteRends;

  public List<ParticleSystem> particleSystems;

  private void OnValidate()
  {

    if (checkpoints == null || checkpoints[0] == null) return;

    Vector3 pos1 = checkpoints[0].localPosition;
    pos1.x = checkPoint1 - 0.5f;
    checkpoints[0].localPosition = pos1;

    Vector3 pos2 = checkpoints[1].localPosition;
    pos2.x = checkPoint2 - 0.5f;
    checkpoints[1].localPosition = pos2;

    Vector3 pos3 = checkpoints[2].localPosition;
    pos3.x = checkPoint3 - 0.5f;
    checkpoints[2].localPosition = pos3;
  }

  //private void OnValidate()
  //{
  //  if (rend == null) rend = GetComponent<Renderer>();

  //rend.material.SetFloat("_Progress", progress);
  //}

  // Start is called before the first frame update
  void Awake()
  {
    rend = GetComponent<Renderer>();
  }

  private void Update()
  {
    if(hiddenProgress < progress)
    {
      hiddenProgress += progressLerpSpeed * Time.deltaTime;

      if (hiddenProgress > progress) hiddenProgress = progress;
    }

    if(rend.material.GetFloat("_Progress") != hiddenProgress)
    {
      rend.material.SetFloat("_Progress", hiddenProgress);
      CheckMilestone();
    }
  }

  private void CheckMilestone()
  {
    switch(starAmt)
    {
      case 0:
        if (hiddenProgress >= checkPoint1)
        {
          starAmt++;
          starSpriteRends[0].color = Color.white;
          particleSystems[0].Play();

          AudioStatics.PlayOneShotAtLocation("event:/sfx_star", Vector3.zero);
        }
        break;
      case 1:
        if (hiddenProgress >= checkPoint2)
        {
          starAmt++;
          starSpriteRends[1].color = Color.white;
          starSpriteRends[2].color = Color.white;
          particleSystems[1].Play();

          AudioStatics.PlayOneShotAtLocation("event:/sfx_star", Vector3.zero);
        }
        break;
      case 2:
        if (hiddenProgress >= checkPoint3)
        {
          starAmt++;
          starSpriteRends[3].color = Color.white;
          starSpriteRends[4].color = Color.white;
          starSpriteRends[5].color = Color.white;
          particleSystems[2].Play();

          AudioStatics.PlayOneShotAtLocation("event:/sfx_star", Vector3.zero);
        }
        break;
    }
  }

  private void Reset()
  {
    foreach(SpriteRenderer rend in starSpriteRends)
    {
      progress = 0;
      rend.color = Color.black;
      starAmt = 0;
      hiddenProgress = 0;
    }
  }

}
