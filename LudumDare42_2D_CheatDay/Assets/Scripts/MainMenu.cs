using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour {

    public TextMeshProUGUI highscoreText;

    private void Start()
    {
        highscoreText.text = "Current HighScore: \n " + PlayerPrefs.GetString("HighScoreName", "") + " " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitButton()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }

    public void ClearHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        PlayerPrefs.DeleteKey("HighScoreName");
        highscoreText.text = "Current HighScore: \n " + PlayerPrefs.GetString("HighScoreName", "") + " " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
}
