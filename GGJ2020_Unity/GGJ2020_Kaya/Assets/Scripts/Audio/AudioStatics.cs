using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;


public static class AudioStatics
{
    // NOT DONE
    public static void LoadBank()
    {
        //RuntimeManager.LoadBank();  //will make a list for this later.
    }

    // NOT DONE
    public static void Pause()
    {
        // run a override snapshot or set bus values
    }

    public static void SetListenerPos(Transform t)
    {
        RuntimeManager.SetListenerLocation(t);
    }

    public static void SetParameterValue(StudioEventEmitter audioEventEmitter, string name, float value)
    {
        audioEventEmitter.SetParameter(name, value);
    }

    public static void StopEvent(StudioEventEmitter audioEventEmitter)
    {
        if (audioEventEmitter.IsPlaying())
            audioEventEmitter.Stop();
    }

    public static void PlayEvent(StudioEventEmitter audioEventEmitter)
    {
        audioEventEmitter.Play();
    }

    public static void PlayOneShotAtLocation(string eventPath, Vector3 pos)
    {
        RuntimeManager.PlayOneShot(eventPath, pos);
    }

    public static void PlayOneShotAttached(string eventPath, GameObject target)
    {
        RuntimeManager.PlayOneShotAttached(eventPath, target);
    }

}
