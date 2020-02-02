using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Ingame_BGM : MonoBehaviour
{
  public bool playWaveSound = false;

  [Range(0,1)]
  public float waveMatching = 0;
  [Range(0,4)]
  public int bgmLevel = 0;

  public StudioEventEmitter sineEvent, bgmEvent;


  Head_AniScript[] heads;

  // Start is called before the first frame update
  void Start()
  {
    if(playWaveSound)AudioStatics.PlayEvent(sineEvent);
    AudioStatics.PlayEvent(bgmEvent);

    heads = FindObjectsOfType<Head_AniScript>();

  }

  // Update is called once per frame
  void Update()
  {

  }

	public void StopBGM()
	{
		AudioStatics.StopEvent(bgmEvent);
	}

  public void UpdateBGM(int _bgmLevel)
  {
    bgmEvent.SetParameter("stage", _bgmLevel);
    bgmLevel = _bgmLevel;
  }

  public void UpdateMatchRate(float _waveMatching)
  {
    sineEvent.SetParameter("Progress", _waveMatching);
    waveMatching = _waveMatching;

    foreach (Head_AniScript head in heads)
    {
      head.UpdateMatch(_waveMatching);
    }
  }

  public void UpdateBoth(float _waveMatching, int _bgmLevel)
  {
    UpdateBGM(_bgmLevel);
    UpdateMatchRate(_waveMatching);

  }

  // private void OnValidate()
  // {
  //   UpdateBoth(waveMatching, bgmLevel);
  // }

}
