using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float enemySpawnTime;
    [SerializeField] private float left;
    [SerializeField] private float right;

    private float timer;

    // Update is called once per frame
    void Update()
    {
        if (timer > enemySpawnTime)
        {
            SpawnEnemy();
            timer = 0;
        }
        else timer += Time.deltaTime;
    }

    void SpawnEnemy() {
        Vector2 spawnPos = new Vector2(Random.Range(left, right), 7);

        GameObject enemy = ObjectPool.Instance.GetPooledEnemy();

        if (enemy != null)
        {
            Debug.Log(spawnPos);
            enemy.transform.position = spawnPos;
            enemy.SetActive(true);
        }
    }
}
