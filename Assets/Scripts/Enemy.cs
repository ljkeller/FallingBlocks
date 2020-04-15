using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    public Vector2 speedMinMax;

    float visibleHeightThreshold;


    private void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.getDifficultyPercent());
        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
    }


    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        CleanupGO.destroyIfBelowThreshold(gameObject, transform.localScale.y);
    }
}
