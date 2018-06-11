using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public int levelDuration = 0;
    private float timer;
    private bool completed = false;

    private void Awake()
    {
        GameManager.Get().player = GameObject.FindGameObjectWithTag("Player");
        GameManager.Get().levelManager = GameObject.FindGameObjectWithTag("LevelManager");
        GameManager.Get().listOfEnemies = GameObject.FindGameObjectWithTag("EnemyList");
    }

    private void Start()
    {
        GameManager.Get().UpdateStats();
    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        if (timer>= levelDuration)
            completed = true;
	}

    public bool IsCompleted()
    {
        return completed;
    }

    public float GetTime()
    {
        return timer;
    }

    public int GetDuration()
    {
        return levelDuration;
    }

}
