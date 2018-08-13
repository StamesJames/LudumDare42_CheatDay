using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {

    #region Singleton

    public static GameManager Instance;

    #endregion

    #region public variables

    public GameObject player;
    public GameObject conscienceObject;
    public float maxKalorieLevel;
    public float conscienceStartDistance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public FoodSpawn[] foodSpawns;
    public int amountFood;
    public string stomachDeathText;
    public string gutDeathText;
    public string conscienceDeathText;
    public string poopDeathText;
    public AudioClip DeathSound;
    public TextMeshProUGUI highScoreText;
    public GameObject newHighScoreMenu;
    #endregion

    #region private variales

    private float currentKalorieLevel;
    private bool gameOver = false;
    private List<FoodSpawn> emptyFoodSpawns = new List<FoodSpawn>();
    private AudioSource audioScource;

    #endregion

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("There should be only one GameManager");
        }
        else
        {
            Instance = this;
        }
        Time.timeScale = 1f;
    }

    private void Start()
    {
        currentKalorieLevel = 0f;
        scoreText.text = "";

        Vector2 conscienceDirection = Random.insideUnitCircle.normalized;
        Instantiate(conscienceObject, player.transform.position + new Vector3 (conscienceDirection.x, conscienceDirection.y, 0f) * conscienceStartDistance, Quaternion.identity);

        audioScource = GetComponent<AudioSource>();

        StartGameSetUp();

    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel") && !gameOver)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
    }

    public void SpawnFood(FoodSpawn oldFoodSpawn)
    {
        int randomInt = Random.Range(0, emptyFoodSpawns.Count);
        emptyFoodSpawns[randomInt].SpawnFood();

        emptyFoodSpawns.RemoveAt(randomInt);
        emptyFoodSpawns.Add(oldFoodSpawn);

    }

    public void AddKalories(float kalorieAmount)
    {
        currentKalorieLevel += kalorieAmount;
        UpdateKalorieSlider();
    }

    public void UpdateKalorieSlider()
    {
            scoreText.text = "Score: " + currentKalorieLevel.ToString();     
    }

    public void DieBecauseOfStomach()
    {
        UpdateHighScore();
        gameOverText.text = stomachDeathText;
        gameOver = true;
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("wegen Stomach gedieedet");
    }

    public void DieBecauseOfGut()
    {
        UpdateHighScore();
        gameOverText.text = gutDeathText;
        gameOver = true;
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("wegen Gut gedieedet");
    }

    public void DieBecuaseConscience()
    {
        UpdateHighScore();
        gameOverText.text = conscienceDeathText;
        gameOver = true;
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("wegen Conscience gedieedet");
    }

    public void DieBecausePoop()
    {
        UpdateHighScore();
        gameOverText.text = poopDeathText;
        gameOver = true;
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("wegen Conscience gedieedet");
    }

    public void UpdateHighScore()
    {
        if (PlayerPrefs.GetInt("HighScore", 0) < currentKalorieLevel)
        {
            PlayerPrefs.SetInt("HighScore", (int) currentKalorieLevel);
            newHighScoreMenu.SetActive(true);
        }
        else
        {
            highScoreText.text = "Highscore: \n " + PlayerPrefs.GetString("HighScoreName", " ") + " " + PlayerPrefs.GetInt("HighScore", 0).ToString(); 
        }
        audioScource.PlayOneShot(DeathSound, 5);
    }

    public void UpdateHighScoreText()
    {
        highScoreText.text = "Highscore: \n " + PlayerPrefs.GetString("HighScoreName", " ") + " " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    private void StartGameSetUp()
    {
        for (int i = 0; i < foodSpawns.Length; i++)
        {
            Debug.Log( i + " Spawn in Empty getan");
            emptyFoodSpawns.Add(foodSpawns[i]);
        }

        for (int i = 0; i < amountFood; i++)
        {
            int randomInt = Random.Range(0, emptyFoodSpawns.Count);
            emptyFoodSpawns[randomInt].SpawnFood();
            emptyFoodSpawns.RemoveAt(randomInt);
        }
    }


}
