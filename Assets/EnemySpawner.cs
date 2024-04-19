using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //add later - when there are multiple enemies
    //public GameObject[] enemies;
    //GameObject randomEnemy = Enemy[Random.Range(0, enemies.Length)];
    public GameObject Enemy;
    public Transform Target;
    public float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            float value = Random.Range(0, 5);
            //Debug.Log(value);
            if (value == 0)
            {
                spawnEnemy();
            }
            yield return new WaitForSeconds(spawnTime);
        }
    }

    void spawnEnemy()
    {
        Vector3 spawnPosition = transform.position;
        Instantiate(Enemy, spawnPosition, Quaternion.identity);
        //Enemy.GetComponent<EnemyMovement>().SetTarget(Target.position);
        //enemyMovement.SetTarget(Target.position);
    }
}
