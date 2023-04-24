﻿using System.Collections;
using System.Collections.Generic;
using Tactics.Attributes;
using Tactics.Movement.Enemies;
using Tactics.Stats;
using Tactics.UI;
using UnityEngine;

namespace Tactics.Enemies
{
    public class EnemyController : MonoBehaviour, IModifierProvider
    {
        private int waveCounter;

        [SerializeField]
        private GameObject lowerEnemy;

        void Start()
        {
            waveCounter = EnemySpawner.GetWave();

            GetComponent<Health>().onDeath += OnDeath;
        }

        public IEnumerable<float> GetAdditiveModifers(Stat stat)
        {
            yield return 0;
        }

        public IEnumerable<float> GetPercentageModifers(Stat stat)
        {
            if (stat == Stat.Health)
                yield return 100 * ((float)waveCounter / 3f);

            if (stat == Stat.Speed && PlayButton.IsFast())
                yield return 100;
        }

        void OnDeath() 
        {
            if (lowerEnemy != null)
            {
                for (int i = 0; i < Random.Range(1, 11); i++)
                {
                    GameObject enemy = Instantiate(lowerEnemy, transform.parent);
                    enemy.transform.position = transform.position;
                    enemy.transform.rotation = transform.rotation;
                    enemy.GetComponent<TileMovement>().currentWaypoint = GetComponent<TileMovement>().currentWaypoint;
                }
            }
            Destroy(gameObject);
        }
    }
}