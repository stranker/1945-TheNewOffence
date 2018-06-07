using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;
    private int score = 0;
    public GameObject player;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {

    }

    public static GameManager Get()
    {
        return instance;
    }

    public void SetScore(int val)
    {
        score = val;
    }

    public int GetScore()
    {
        return score;
    }
}
