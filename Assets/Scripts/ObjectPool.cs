using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance { get; private set; }

    private List<GameObject> pooledBullets = new List<GameObject>();
    private List<GameObject> pooledEnemies = new List<GameObject>();

    [SerializeField] private int amountToPool;
    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private GameObject enemyPrefabs;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < amountToPool; ++i)
        {
            GameObject bullet = Instantiate(bulletPrefabs);
            bullet.SetActive(false);
            pooledBullets.Add(bullet);

            GameObject enemy = Instantiate(enemyPrefabs);
            enemy.SetActive(false);
            pooledEnemies.Add(enemy);
        }
    }

    public GameObject GetPooledBullet() {
        for (int i = 0; i < pooledBullets.Count; ++i) {
            if (!pooledBullets[i].activeInHierarchy) { 
                return pooledBullets[i];
            }
        }

        return null;
    }

    public GameObject GetPooledEnemy()
    {
        for (int i = 0; i < pooledEnemies.Count; ++i)
        {
            if (!pooledEnemies[i].activeInHierarchy)
            {
                return pooledEnemies[i];
            }
        }

        return null;
    }
}
