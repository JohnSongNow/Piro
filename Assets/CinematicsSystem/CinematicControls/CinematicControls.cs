using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CinematicControls : MonoBehaviour
{
    public Cinematic cinematic;
    public GameObject cutsceneButtonsLayout;

    public Button buttonPrefab;

    private void Start()
    {
        if (cinematic != null)
        {
            SetCinematic(cinematic);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (cinematic != null)
            {
                cinematic.Next();
            }
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            cinematic.cutscenes[cinematic.currCutscene].Restart();
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            float alpha = gameObject.GetComponent<CanvasGroup>().alpha;
            gameObject.GetComponent<CanvasGroup>().alpha = alpha == 0 ? 1 : 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void SetCinematic(Cinematic cinematic)
    {
        this.cinematic = cinematic;

        SceneUtility.RemoveAndDestroyChildren(cutsceneButtonsLayout.transform);

        foreach (Cutscene cutscene in cinematic.cutscenes)
        {
            Button button = Instantiate(buttonPrefab);
            button.name = "Cutscene";
            button.GetComponentInChildren<Text>().text = cutscene.name;
            button.transform.parent = cutsceneButtonsLayout.transform;
            button.transform.localScale = new Vector3(1, 1, 1);
            button.onClick.AddListener(() => OnCutsceneButtonClicked(cutscene));
        }
    }

    public void OnCutsceneButtonClicked(Cutscene cutscene)
    {
        cinematic.PlayCutscene(cinematic.cutscenes.IndexOf(cutscene));
    }
}
