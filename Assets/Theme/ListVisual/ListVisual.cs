using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListVisual : MonoBehaviour
{
    public int heightPerInt = 10;
    public int widthPerBar = 20;
    public List<int> numbers { get; private set; }
    public GameObject barPrefab;

    public void SetNumbers(List<int> numbers)
    {
        this.numbers = numbers;

        SceneUtility.RemoveAndDestroyChildren(transform);
        foreach (int number in numbers)
        {
            GameObject listVisualBar = Instantiate(barPrefab, transform);
            listVisualBar.transform.localScale = new Vector3(widthPerBar, number * heightPerInt, 1);
            listVisualBar.GetComponent<RectTransform>().sizeDelta = new Vector3(widthPerBar, number * heightPerInt);
        }
    }

    public void ShuffleList()
    {
        int n = numbers.Count;
        while (n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, n);
            SwapNumbers(k, n);
        }
    }

    public void SwapNumbers(int indexOne, int indexTwo)
    {
        if ((indexOne < 0 || indexOne >= numbers.Count) || (indexTwo < 0 || indexTwo >= numbers.Count))
        {
            return;
        }

        int value = numbers[indexTwo];
        numbers[indexTwo] = numbers[indexOne];
        numbers[indexOne] = value;

        Transform barOne = gameObject.transform.GetChild(indexOne);
        Transform barTwo = gameObject.transform.GetChild(indexTwo);
        barOne.SetSiblingIndex(indexTwo);
        barTwo.SetSiblingIndex(indexOne);
    }

    public void Highlight(int index, Color colour)
    {
        if ((index < 0 || index >= numbers.Count))
        {
            return;
        }

        gameObject.transform.GetChild(index).GetComponent<SpriteRenderer>().color = colour;
    }

    public void SetNumberAtIndex(int index, int value)
    {
        if ((index < 0 || index >= numbers.Count))
        {
            return;
        }

        numbers[index] = value;
        Transform listVisualBar = gameObject.transform.GetChild(index);
        listVisualBar.localScale = new Vector3(20, value * 10, 30);
        listVisualBar.GetComponent<RectTransform>().sizeDelta = new Vector3(20, value * 10);
        LayoutRebuilder.MarkLayoutForRebuild(this.GetComponent<RectTransform>());
    }
}
