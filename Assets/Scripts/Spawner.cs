﻿using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] obstaclePatterns;
    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    private readonly float maxSpawnTime = 0.8F;
    public float decreaseTime;
    
    private void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            int rand = Random.Range(0, obstaclePatterns.Length);
            Instantiate(obstaclePatterns[rand], transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
            if (timeBtwSpawn > maxSpawnTime)
            {
                startTimeBtwSpawn -= decreaseTime;
            }
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
        
    }
}
