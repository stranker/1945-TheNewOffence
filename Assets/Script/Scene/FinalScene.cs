using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalScene : MonoBehaviour {

    public Text scoreText;
    public Text enemiesText;
    public Text shootsText;
    public Text accuracyText;

    // Use this for initialization
    void Start () {
        scoreText.text = GameManager.Get().totalScore.ToString();
        enemiesText.text = "Enemies destroyed " + GameManager.Get().totalEnemiesKilled.ToString();
        shootsText.text = "Shoots fired " + GameManager.Get().totalShootsFired.ToString();
        float accuracy = 0;
        if (GameManager.Get().totalShootsFired > 0)
            accuracy = (GameManager.Get().totalEnemiesKilled * 100 / GameManager.Get().totalShootsFired);
        accuracyText.text = "Accuracy " + accuracy.ToString() + "%";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Destroy(GameManager.Get());
            SceneManager.LoadScene("MainMenu");
        }
    }

}
