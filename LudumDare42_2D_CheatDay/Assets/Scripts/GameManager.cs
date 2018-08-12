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
    public Slider kalorieLevelSlider;
    public float maxKalorieLevel;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public FoodSpawn[] foodSpawns;
    public int amountFood;
    public string stomachDeathText;
    public string gutDeathText;
    public string conscienceDeathText;

    #endregion

    #region private variales

    private float currentKalorieLevel;
    private bool gameOver = false;
    private List<FoodSpawn> emptyFoodSpawns = new List<FoodSpawn>();
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
        kalorieLevelSlider.minValue = 0f;
        kalorieLevelSlider.maxValue = maxKalorieLevel;
        scoreText.text = "";

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
        if (currentKalorieLevel <= maxKalorieLevel)
        {
            kalorieLevelSlider.value = currentKalorieLevel;
        }
        else
        {
            scoreText.text = "Score: " + currentKalorieLevel.ToString();
        }
    }

    public void DieBecauseOfStomach()
    {
        gameOverText.text = stomachDeathText;
        gameOver = true;
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("wegen Stomach gedieedet");
    }

    public void DieBecauseOfGut()
    {
        gameOverText.text = gutDeathText;
        gameOver = true;
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("wegen Gut gedieedet");
    }

    public void DieBecuaseConscience()
    {
        gameOverText.text = conscienceDeathText;
        gameOver = true;
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("wegen Conscience gedieedet");
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
