using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPos;

    public float timesBetweenWaves;

    private int waveNumbers = 1;

    private float countdown;

    private void Start()
    {
        countdown = timesBetweenWaves;
    }
    void Update()
    {
        if(countdown <= 0 && waveNumbers <= 5)
        {
            StartCoroutine(SpawnWave());
            countdown = timesBetweenWaves;
        }
        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveNumbers; i++)
        {
            Instantiate(enemyPrefab, spawnPos.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
        waveNumbers++;
    }
}
