using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField]
    private int maxHealthPoints;

    [SerializeField]
    private int killReward;

    private float currentHealthPoints;

    void Start()
    {
        currentHealthPoints = maxHealthPoints; 
    }

    public void RemoveHealth(float amount) 
    {
        currentHealthPoints -= amount;
        if (currentHealthPoints <= 0) 
        {
            Destroy(gameObject);
            CoinsChanger.ChangeCoins(killReward);
        }
    }

    public float GetPercentage() { return (float)currentHealthPoints / (float)maxHealthPoints; }
}
