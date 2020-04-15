using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CleanupGO 
{
    static float visibleHeightThreshold = -Camera.main.orthographicSize;

    public static void destroyIfBelowThreshold(GameObject gameObject, float maxObjectRadius)
    {
        if(gameObject.transform.position.y + maxObjectRadius < visibleHeightThreshold)
        {
            UnityEngine.GameObject.Destroy(gameObject);
        }
    }
}
