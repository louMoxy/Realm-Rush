using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] int numberOfEnemiesInWave = 5;
    [SerializeField] GameObject enemy;
    [SerializeField] float spawnTimer = 1f;

    void Start()
    {
        StartCoroutine(spawnEnemy());   
    }


    IEnumerator spawnEnemy()
    {
        while(numberOfEnemiesInWave > 0)
        {
            Instantiate(enemy, transform);
            numberOfEnemiesInWave--;
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
