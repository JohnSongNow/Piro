using System;
using UnityEngine;

public class WaitForNextStep : CustomYieldInstruction
{
    private Cutscene cutscene;
    private bool waitingForStep = true;

    public WaitForNextStep(Cutscene cutscene)
    {
        this.cutscene = cutscene;
        cutscene.stepBegan += OnStepBegan;
    }

    public override bool keepWaiting
    {
        get
        {
            return waitingForStep;
        }
    }

    private void OnStepBegan(object sender, EventArgs e)
    {
        cutscene.stepBegan -= OnStepBegan;
        waitingForStep = false;
    }
}
