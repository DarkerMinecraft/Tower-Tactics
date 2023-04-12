using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField]
    private int maxHealthPoints;

    private int currentHealthPoints;

    void Start()
    {
        currentHealthPoints = maxHealthPoints; 
    }

    public void RemoveHealth(int amount) 
    {
        currentHealthPoints -= amount;
        if (currentHealthPoints <= 0) 
        {
            Destroy(gameObject);
        }
    }

    public float GetPercentage() { return (float)currentHealthPoints / (float)maxHealthPoints; }
}
