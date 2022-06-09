using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpwanManager : MonoBehaviour
{
    public GameObject powerup;
    public GameObject enemy;

    public float spawnRange;

    public int enemyCount;
    private int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(powerup, randomisingPos(), powerup.transform.rotation);
        SpawnWave(waveNumber);
    }

    void SpawnWave(int enemiesSpawn)
    {
        for(int i = 1; i <=enemiesSpawn; i++)
        {
            Instantiate(enemy, randomisingPos(), enemy.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0)
        {
            waveNumber++;
            Instantiate(powerup, randomisingPos(), powerup.transform.rotation);
            SpawnWave(waveNumber);
        }
    }

    private Vector3 randomisingPos()
    {
        float posX = Random.Range(-spawnRange, spawnRange);
        float posZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3 (posX, 0, posZ);

        return randomPos;

    }
}
