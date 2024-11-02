using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public float spawnTime = 2;
    private float timer;
    private int currentEnemy;
    // Start is called before the first frame update
    void Start()
    {
        timer = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab[currentEnemy], transform.position, Quaternion.identity);
        currentEnemy++;
        if(currentEnemy >= enemyPrefab.Length)
            this.enabled = false;
        timer = spawnTime;
    }
}
