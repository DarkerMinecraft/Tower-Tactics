using System.Collections;
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
                yield return 150 * ((float)(waveCounter / 12));

            if (stat == Stat.Speed)
                yield return 75 * ((float)(waveCounter / 12));

            if (stat == Stat.Speed && PlayButton.IsFast())
                yield return 100;
        }

        void OnDeath()
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<TileMovement>().enabled = false;

            if (lowerEnemy != null)
                SpawnLowerEnemies();
            Destroy(gameObject);
        }

        private IEnumerator SpawnLowerEnemies()
        {
            for (int i = 0; i < Random.Range(1, 11); i++)
            {
                GameObject enemy = Instantiate(lowerEnemy, transform.parent);
                enemy.GetComponent<TileMovement>().path = GetComponent<TileMovement>().path;
                yield return new WaitForSeconds(PlayButton.IsFast() ? 0.3f / 2 : 0.3f);
            }
        }
    }
}