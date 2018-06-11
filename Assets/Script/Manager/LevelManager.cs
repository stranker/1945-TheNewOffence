using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public int levelDuration = 0;
    private float timer;
    public bool completed = false;

    private void Start()
    {
        GameManager.Get().currentLevel++;
    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        if (timer>= levelDuration)
        {
            completed = true;
        }
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
