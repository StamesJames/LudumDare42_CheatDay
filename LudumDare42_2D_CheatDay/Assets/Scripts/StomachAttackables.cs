using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StomachAttackables : MonoBehaviour {

    #region public variables

    public float startHealth;
    public float feacesAmount;
    public float kalorieAmount;

    #endregion

    #region private variables

    private float currentHealth;

    #endregion


    private void Start()
    {
        currentHealth = startHealth;
    }

    public void takeDamage(float damage)
    {
        Debug.Log("taken Damage");
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        GutManager.Instance.AddFeaces(feacesAmount);
        GameManager.Instance.AddKalories(kalorieAmount);
        Destroy(gameObject);
    }
}
