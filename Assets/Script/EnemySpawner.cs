using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public List<GameObject> enemies;
    public int normalEnemyTime = 2;
    public int groupEnemyTime = 3;
    public float timerNormalEnemy;
    public float timerGroupEnemy;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
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

    private void SpawnGroupEnemy()
    {
        Instantiate(enemies[1], transform.position, enemies[1].transform.rotation, transform.parent);
    }

    private void SpawnNormalEnemy()
    {
        Instantiate(enemies[0], transform.position, enemies[0].transform.rotation, transform.parent);
    }
}
