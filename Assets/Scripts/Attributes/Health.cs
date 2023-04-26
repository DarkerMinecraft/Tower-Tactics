using System;
using System.Collections;
using System.Collections.Generic;
using Tactics.Stats;
using Tactics.UI;
using UnityEngine;

namespace Tactics.Attributes
{
    public class Health : MonoBehaviour
    {

        private float maxHealthPoints;

        private float currentHealthPoints;

        private BaseStats baseStats;

        public Action onDeath; 

        private void Awake()
        {
            baseStats = GetComponent<BaseStats>();
        }

        void Start()
        {
            maxHealthPoints = baseStats.GetStat(Stat.Health);
            currentHealthPoints = maxHealthPoints;
        }

        public void RemoveHealth(float amount)
        {
            currentHealthPoints -= amount;
            if (currentHealthPoints <= 0)
            {
                onDeath.Invoke();
                CoinsChanger.ChangeCoins(Mathf.CeilToInt(baseStats.GetStat(Stat.KillReward)));
            }
        }

        public float GetPercentage() { return (float)currentHealthPoints / (float)maxHealthPoints; }

    }
}
