using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public int levelScore = 0;
    public int totalScore = 0;
    public int totalEnemiesKilled = 0;
    public int levelEnemiesKilled = 0;
    public int totalShootsFired = 0;
    public GameObject player;
    public GameObject levelManager;
    public bool isPaying = true;
    public int currentScene = 1;
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
        player = GameObject.FindGameObjectWithTag("Player");
        levelManager = GameObject.FindGameObjectWithTag("LevelManager");
        listOfEnemies = GameObject.FindGameObjectWithTag("EnemyList");
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
                NextScene();
            }
        }
    }

    public void NextScene()
    {
        if (currentScene - currentLevel == 2) // Ultima Escena transicion
            SceneManager.LoadScene("FinalScene");
        if (currentScene % 2 != 0) // Escena jugable
        {
            SceneManager.LoadScene("TransitionScene");
            canChangeScene = true;
        }
        else
        {
            totalScore += levelScore;
            totalEnemiesKilled += levelEnemiesKilled;
            isPaying = true;
            currentScene++;
            canChangeScene = true;
            SceneManager.LoadScene(currentScene);
        }
    }

    public static GameManager Get()
    {
        return instance;
    }
}
