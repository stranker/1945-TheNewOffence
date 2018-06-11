using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public Text scoreText;
    public Text bombsText;
    public Image energyBar;
    public float energy;
    public int score;
    public int bombs;
    // Use this for initialization
    void Start () {
        score = GameManager.Get().levelScore;
        bombs = GameManager.Get().player.GetComponent<PlayerAirplane>().GetBombs();
        energy = GameManager.Get().player.GetComponent<PlayerAirplane>().GetEnergy();
        scoreText.text = "SCORE " + score.ToString();
        bombsText.text = bombs.ToString();
        energyBar.fillAmount = energy / GameManager.Get().player.GetComponent<PlayerAirplane>().GetMaxEnergy();
    }
	
	// Update is called once per frame
	void Update () {
        if (score != GameManager.Get().levelScore)
        {
            score = GameManager.Get().levelScore;
            scoreText.text = "SCORE " + score.ToString();
        }
        if (bombs != GameManager.Get().player.GetComponent<PlayerAirplane>().GetBombs())
        {
            bombs = GameManager.Get().player.GetComponent<PlayerAirplane>().GetBombs();
            bombsText.text = bombs.ToString();
        }
        if (energy != GameManager.Get().player.GetComponent<PlayerAirplane>().GetEnergy())
        {
            energy = GameManager.Get().player.GetComponent<PlayerAirplane>().GetEnergy();
            energyBar.fillAmount = energy / GameManager.Get().player.GetComponent<PlayerAirplane>().GetMaxEnergy();
        }
	}
}
