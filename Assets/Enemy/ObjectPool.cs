using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] int numberOfEnemiesInWave = 5;
    [SerializeField] GameObject enemy;
    [SerializeField] float spawnTimer = 1f;

    GameObject[] pool;

    private void Awake()
    {
        PopulatePool();
    }

    void Start()
    {
        StartCoroutine(spawnEnemy());   
    }

    private void PopulatePool()
    {
        pool = new GameObject[numberOfEnemiesInWave];
        for(int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemy, transform);
            pool[i].SetActive(false);
        }
    }

    IEnumerator spawnEnemy()
    {
        while(numberOfEnemiesInWave > 0)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    private void EnableObjectInPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            GameObject gameObject = pool[i];
            if (!gameObject.activeInHierarchy)
            {
                gameObject.SetActive(true);
                return;
            }
        }
    }
}
