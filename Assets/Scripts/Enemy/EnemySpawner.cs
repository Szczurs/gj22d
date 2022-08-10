using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();

    [SerializeField] GameObject enemySpawner;

    [SerializeField] GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        enemySpawner = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        if (enemies.Count == 0)
        {
            //spawn another enemy
            GameObject enemy = Instantiate(enemyPrefab, enemySpawner.transform.position, enemySpawner.transform.rotation);
            //enemies.Add(enemy);
        }
    }
}
