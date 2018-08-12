using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

    #region public variables

    public float kalories = 20;
    public GameObject stomachObject;
    public FoodSpawn myFoodSpawn;

    #endregion

    #region private variables

    [HideInInspector]
    public float currentProgress;

    #endregion

    private void Start()
    {
        currentProgress = kalories;
    }

    public bool EatMe(float amount)
    {
        currentProgress -= amount;
        if (currentProgress <= 0)
        {
            GameManager.Instance.SpawnFood(myFoodSpawn);
            return true;
        }


        return false;
    }


    public void StopEating()
    {
        currentProgress = kalories;
    }

    public float GetCurrentProgress()
    {
        return ((kalories - currentProgress) / kalories);
    }

}
