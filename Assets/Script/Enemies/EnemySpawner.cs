using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public List<GameObject> enemies;
    public int normalEnemyTime = 2;
    public int groupEnemyTime = 5;
    public float timerNormalEnemy;
    public float timerGroupEnemy;
    public int timeEndSpawn = 5;
    private LevelManager levelManager;

    private void Start()
    {
        levelManager = GameManager.Get().levelManager.GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update () {
        if (levelManager.GetDuration() - timeEndSpawn > levelManager.GetTime())
        {
            timerNormalEnemy += Time.deltaTime;
            timerGroupEnemy += Time.deltaTime;
            if (timerNormalEnemy > normalEnemyTime)
            {
                SpawnNormalEnemy();
                timerNormalEnemy = 0;
            }
            if (timerGroupEnemy > groupEnemyTime)
            {
                SpawnGroupEnemy();
                timerGroupEnemy = 0;
            }
        }
    }

    private void SpawnGroupEnemy()
    {
        Instantiate(enemies[1], transform.position, enemies[1].transform.rotation, GameManager.Get().listOfEnemies.transform);
    }

    private void SpawnNormalEnemy()
    {
        Instantiate(enemies[0], transform.position, enemies[0].transform.rotation, GameManager.Get().listOfEnemies.transform);
    }
}
