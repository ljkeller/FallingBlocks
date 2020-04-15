using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public Vector2 spawnPeriodMinMax_s = new Vector2(0.3f, 1f);
    float nextSpawnTime_s;

    public float viableSpawnAngleMax = 15f;
    public Vector2 spawnSizeMinMax;

    Vector2 screenHalfSizeWorldUnits;
    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize - transform.localScale.x / 2, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime_s)
        {
            float spawnPeriod_s = Mathf.Lerp(spawnPeriodMinMax_s.y, spawnPeriodMinMax_s.x, Difficulty.getDifficultyPercent());
            nextSpawnTime_s = Time.time + spawnPeriod_s;

            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
            float spawnAngle = Random.Range(-viableSpawnAngleMax, viableSpawnAngleMax);
            Vector2 randomStartPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), Random.Range(screenHalfSizeWorldUnits.y, 2 * screenHalfSizeWorldUnits.y));
            GameObject enemy = Instantiate(enemyPrefab, randomStartPosition, Quaternion.Euler(Vector3.forward * spawnAngle), transform);
            enemy.transform.localScale = Vector2.one * spawnSize;
        }
    }
}
