using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float speed = 6f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float deltaPosY = speed * Time.deltaTime;
        transform.Translate(deltaPosY * Vector2.down);
        CleanupGO.destroyIfBelowThreshold(gameObject, transform.localScale.z);
    }
}
