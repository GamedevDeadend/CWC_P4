using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanManager : MonoBehaviour
{
    public GameObject enemy;

    public float spawnRange;
    // Start is called before the first frame update
    void Start()
    {
        
        Instantiate(enemy, randomisingPos(), enemy.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 randomisingPos()
    {
        float posX = Random.Range(-spawnRange, spawnRange);
        float posZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3 (posX, 0, posZ);

        return randomPos;

    }
}
