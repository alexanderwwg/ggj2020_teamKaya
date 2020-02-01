using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
  [Tooltip("Controls the length of the progress bar")]
  [Range(0, 1)]
  public float progress = 0.5f;

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

  private int starAmt = 0;


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
    if(rend.material.GetFloat("_Progress") != progress)
    {
      rend.material.SetFloat("_Progress", progress);
      CheckMilestone();
    }
  }

  private void CheckMilestone()
  {
    switch(starAmt)
    {
      case 0:
        if (progress >= checkPoint1)
        {
          starAmt++;
          starSpriteRends[0].color = Color.white;
          particleSystems[0].Play();
        }
        break;
      case 1:
        if (progress >= checkPoint2)
        {
          starAmt++;
          starSpriteRends[1].color = Color.white;
          starSpriteRends[2].color = Color.white;
          particleSystems[1].Play();
        }
        break;
      case 2:
        if (progress >= checkPoint3)
        {
          starAmt++;
          starSpriteRends[3].color = Color.white;
          starSpriteRends[4].color = Color.white;
          starSpriteRends[5].color = Color.white;
          particleSystems[2].Play();
        }
        break;
    }
  }

}
