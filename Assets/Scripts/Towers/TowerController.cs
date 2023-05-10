using System.Collections;
using System.Collections.Generic;
using Tactics.Enemies;
using Tactics.Stats;
using Tactics.UI;
using UnityEngine;

namespace Tactics.Towers
{
    public class TowerController : MonoBehaviour, IModifierProvider
    {
      
        [HideInInspector]
        public EnemySpawner spawner;

        [HideInInspector]
        public List<GameObject> inRadiusEnemies;

        [HideInInspector]
        public SpriteRenderer radiusCircle;

        private BaseStats stats;

        public Tower tower;

        private void Awake()
        {
            stats = GetComponent<BaseStats>();  
            radiusCircle = GetComponentsInChildren<SpriteRenderer>()[0];
        }

        void Start()
        {
            inRadiusEnemies = new List<GameObject>();
        }

        void Update()
        {
            if (spawner != null)
            {
                for (int i = 0; i < spawner.transform.childCount; i++)
                {
                    Transform spawnerChild = spawner.transform.GetChild(i);

                    float distance = Vector2.Distance(spawnerChild.position, transform.position);

                    if (!inRadiusEnemies.Contains(spawnerChild.gameObject))
                    {
                        if (distance <= stats.GetStat(Stat.Radius))
                            inRadiusEnemies.Add(spawnerChild.gameObject);
                    }
                    else
                    {
                        if (distance > stats.GetStat(Stat.Radius))
                            inRadiusEnemies.Remove(spawnerChild.gameObject);
                    }
                }

                for (int i = 0; i < inRadiusEnemies.Count; i++)
                {
                    GameObject obj = inRadiusEnemies[i];
                    if (obj == null) inRadiusEnemies.Remove(obj);
                }
            }

            radiusCircle.transform.localScale = new Vector2(GetRadius(), GetRadius());
        }

        public float GetRadius() { return stats.GetStat(Stat.Radius); }

        public IEnumerable<float> GetAdditiveModifers(Stat stat)
        {
            yield return 0;
        }

        public IEnumerable<float> GetPercentageModifers(Stat stat)
        {
            if(stat == Stat.Speed && PlayButton.IsFast())
                yield return 100;

            if (stat == Stat.ShootingTime && PlayButton.IsFast())
                yield return -50;
        }
    }
}
