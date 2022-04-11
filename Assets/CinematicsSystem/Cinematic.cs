using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cinematic : MonoBehaviour
{
    [HideInInspector]
    public int currCutscene;
    public List<Cutscene> cutscenes;

    public Cinematic()
    {
        cutscenes = new List<Cutscene>();
        currCutscene = -1;
    }

    void Start()
    {
        foreach (Cutscene cutscene in cutscenes)
        {
            cutscene.gameObject.SetActive(false);
        }
    }

    public void PlayCutscene(int i)
    {
        foreach (Cutscene cutscene in cutscenes)
        {
            cutscene.gameObject.SetActive(false);
        }

        currCutscene = i;
        cutscenes[i].gameObject.SetActive(true);
        StartCoroutine(cutscenes[i].Play());
    }

    public void Next()
    {
        if (currCutscene <= cutscenes.Count - 1 && currCutscene >= 0)
        {
            cutscenes[currCutscene].Next();
        }
    }
}
