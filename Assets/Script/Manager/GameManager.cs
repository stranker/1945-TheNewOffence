﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public int levelScore = 0;
    public int totalScore = 0;
    public int totalEnemiesKilled = 0;
    public int levelEnemiesKilled = 0;
    public int totalShootsFired = 0;
    public int itemsCollected = 0;
    public GameObject player;
    public GameObject levelManager;
    public bool isPaying = true;
    public int currentScene = 0;
    public int currentLevel = 0;
    public GameObject listOfEnemies;
    public float timer;
    public int nextSceneTime = 4;
    public bool canChangeScene = true;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        CheckLevelCompleted();
    }

    private void CheckLevelCompleted()
    {
        if (levelManager)
            if (levelManager.GetComponent<LevelManager>().IsCompleted() && isPaying)
                isPaying = false;
        if (!isPaying)
        {
            if (listOfEnemies != null)
                if(listOfEnemies.GetComponentsInChildren<Transform>().GetLength(0) <= 1)
                    timer += Time.deltaTime;
            if (timer >= nextSceneTime && canChangeScene)
            {
                timer = 0;
                canChangeScene = false;
                GoToTransitionScene();
            }
        }
    }

    public void NextLevel()
    {
        int nextLevel = currentLevel + 1;
        SceneManager.LoadScene("Level" + nextLevel.ToString());
    }

    public void GoToTransitionScene()
    {
        SceneManager.LoadScene("TransitionScene");
    }

    public void UpdateStats()
    {
        totalScore += levelScore;
        levelScore = 0;
        totalEnemiesKilled += levelEnemiesKilled;
        levelEnemiesKilled = 0;
        currentScene++;
        itemsCollected = 0;
        isPaying = true;
        canChangeScene = true;
        currentLevel++;
    }

    public static GameManager Get()
    {
        return instance;
    }
}
