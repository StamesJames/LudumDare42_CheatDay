using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour {


    public TextMeshProUGUI highScoreText;

    private void OnEnable()
    {
        highScoreText.text = "Highscore: \n " + PlayerPrefs.GetString("HighScoreName", " ") + " " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
