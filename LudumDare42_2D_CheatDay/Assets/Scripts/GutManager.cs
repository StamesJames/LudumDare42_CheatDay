using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GutManager : MonoBehaviour {

    #region Singleton

    public static GutManager Instance;

    #endregion


    #region public variables

    public float maxCapacity;
    public Slider FeacesSlider;

    #endregion

    #region private variables

    private float currentFilling;

    #endregion


    private void Awake()
    {
        if (Instance !=null)
        {
            Debug.Log("There should just be one GutManager");
        }
        else
        {
            Instance = this;
        }

        currentFilling = 0f;
    }

    public void AddFeaces(float amount)
    {
        currentFilling += amount;

        if (currentFilling > maxCapacity)
        {
            GameManager.Instance.DieBecauseOfGut();
        }
        else
        {
            UpdateFeceasSlider();
        }

        
    }

    public bool IsEmpty()
    {

        if (currentFilling > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void UpdateFeceasSlider()
    {
        FeacesSlider.value = currentFilling / maxCapacity;
    }

    public void Poop(float poopAmount)
    {
        currentFilling = Mathf.Max (currentFilling - poopAmount, 0f);
        UpdateFeceasSlider();
    }

}
