using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionManager : MonoBehaviour {

    private void Start()
    {
        GameManager.Get().currentScene++;
    }


    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Insert))
        {
            GameManager.Get().NextScene();
        }
	}
}
