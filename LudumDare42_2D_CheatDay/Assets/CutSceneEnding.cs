using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CutSceneEnding : MonoBehaviour {

    public float waitForEnding = 2f;

    private float timer;
    private bool stop = false;

    private void OnEnable()
    {
        stop = true;
    }

    private void Update()
    {
        if (stop)
        {
            timer += Time.deltaTime;
            if (timer >= waitForEnding)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
