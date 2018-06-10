using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public Text scoreText;
    public int score;
    public Text bombsText;
    public int bombs;
    // Use this for initialization
    void Start () {
        score = GameManager.Get().GetScore();
        bombs = GameManager.Get().player.GetComponent<PlayerAirplane>().GetBombs();
        scoreText.text = "SCORE " + score.ToString();
        bombsText.text = "BOMBS " + bombs.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        if (score != GameManager.Get().GetScore())
        {
            score = GameManager.Get().GetScore();
            scoreText.text = "SCORE " + score.ToString();
        }
        if (bombs != GameManager.Get().player.GetComponent<PlayerAirplane>().GetBombs())
        {
            bombs = GameManager.Get().player.GetComponent<PlayerAirplane>().GetBombs();
            bombsText.text = "BOMBS " + bombs.ToString();
        }
	}
}
