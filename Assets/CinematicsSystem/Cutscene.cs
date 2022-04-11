using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cutscene : MonoBehaviour
{
    private bool playing;

    public event EventHandler cutsceneStarted;
    public event EventHandler cutsceneEnded;
    public event EventHandler stepBegan;
    public event EventHandler stepEnded;

    public virtual IEnumerator Play()
    {
        playing = true;
        OnCutsceneStarted();
        yield return new WaitForEndOfFrame();
    }

    public virtual void Next()
    {
        if (!playing)
        {
            return;
        }

        OnStepBegan();
    }

    public virtual void End()
    {
        playing = false;
        OnCutsceneEnded();
        StopAllCoroutines();
    }

    public virtual void Restart()
    {
        playing = false;
        StopAllCoroutines();
    }

    public void OnCutsceneStarted() => cutsceneStarted?.Invoke(this, EventArgs.Empty);
    public void OnStepBegan() => stepBegan?.Invoke(this, EventArgs.Empty);
    public void OnStepEnded() => stepEnded?.Invoke(this, EventArgs.Empty);
    public void OnCutsceneEnded() => cutsceneEnded?.Invoke(this, EventArgs.Empty);
}
