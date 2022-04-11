using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SceneUtility
{
    public static void RemoveAndDestroyChildren(GameObject gameObject)
    {
        RemoveAndDestroyChildren(gameObject.transform);
    }

    public static void RemoveAndDestroyChildren(Transform rootTransform)
    {
        foreach (Transform transform in rootTransform)
        {
            GameObject.Destroy(transform.gameObject);
        }
        rootTransform.DetachChildren();
    }
}
