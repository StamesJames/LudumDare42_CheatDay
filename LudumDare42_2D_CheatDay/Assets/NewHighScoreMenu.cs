using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class NewHighScoreMenu : MonoBehaviour {

    public TMP_InputField input; 


    public void Send()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetString("HighScoreName", input.text);
        GameManager.Instance.UpdateHighScoreText();
        Time.timeScale = 0f;
    }


}
