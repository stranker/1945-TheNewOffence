using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScene : MonoBehaviour {

    public Text scoreText;
    public Text enemiesText;
    public Text shootsText;
    public Text accuracyText;

    // Use this for initialization
    void Start () {
        scoreText.text = GameManager.Get().totalScore.ToString();
        enemiesText.text = "Enemies killed " + GameManager.Get().totalEnemiesKilled.ToString();
        shootsText.text = "Shoots fired " + GameManager.Get().totalShootsFired.ToString();
        float accuracy = (GameManager.Get().totalEnemiesKilled * 100 / GameManager.Get().totalShootsFired) ;
        accuracyText.text = "Accuracy " + accuracy.ToString() + "%";
    }
}
