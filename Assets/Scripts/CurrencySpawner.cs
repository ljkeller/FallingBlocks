using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencySpawner : MonoBehaviour
{
    public GameObject currencyPrefab;

    public Vector2 spawnPeriodMinMax_s = new Vector2(0.1f, 1f);

    public float nextSpawnTime_s;

    public Vector2 screenHalfSizeInWorldUnits;

    public float screenHalfWidthInWorldUnits;

    public float screenHalfHeightInWorldUnits;
    // Start is called before the first frame update
    void Start()
    {
        screenHalfSizeInWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize - transform.localScale.x / 2, Camera.main.orthographicSize - transform.localScale.y / 2);
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize - transform.localScale.x/2;
        screenHalfHeightInWorldUnits = Camera.main.orthographicSize - transform.localScale.y / 2 ;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime_s)
        {
            float spawnPeriod_s = Mathf.Lerp(spawnPeriodMinMax_s.y, spawnPeriodMinMax_s.x, Difficulty.getDifficultyPercent());
            nextSpawnTime_s = Time.time + spawnPeriod_s;
            Vector2 randomStartPosition = new Vector2(Random.Range(-screenHalfSizeInWorldUnits.x, screenHalfSizeInWorldUnits.x), Random.Range(screenHalfSizeInWorldUnits.y, 2 * screenHalfSizeInWorldUnits.y));
            GameObject coin = Instantiate(currencyPrefab, randomStartPosition, new Quaternion(), transform);
        }
    }
}
