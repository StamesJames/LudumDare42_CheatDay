using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FoodSpawn : MonoBehaviour {

    public GameObject[] foodObjects;


    public void SpawnFood()
    {
        Debug.Log("In Spawn drinne");
        int randomInt = Random.Range(0, foodObjects.Length);
        Food newFood =  Instantiate(foodObjects[randomInt], transform.position, Quaternion.identity).GetComponent<Food>();
        newFood.myFoodSpawn = this;
    }

}
