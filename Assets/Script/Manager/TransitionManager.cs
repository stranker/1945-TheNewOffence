using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour {

    public Text score, items, enemies;
    public int nonLevelScenes = 3;
    public int cantLevels; 
    private void Start()
    {
        cantLevels = SceneManager.sceneCountInBuildSettings - nonLevelScenes;
        GameManager.Get().currentScene++;
        score.text = GameManager.Get().levelScore.ToString();
        items.text = "Items collected " + GameManager.Get().itemsCollected.ToString();
        enemies.text = "Enemies destroyed " + GameManager.Get().levelEnemiesKilled.ToString();
    }


    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (GameManager.Get().currentLevel == cantLevels)
            {
                GameManager.Get().UpdateStats();
                SceneManager.LoadScene("FinalScene");
            }
            else
                GameManager.Get().NextLevel();
        }
	}
}
