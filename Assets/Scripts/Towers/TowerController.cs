using System.Collections;
using System.Collections.Generic;
using Tactics.Enemies;
using Tactics.Stats;
using UnityEngine;

namespace Tactics.Towers
{
    public class TowerController : MonoBehaviour
    {
      
        [HideInInspector]
        public EnemySpawner spawner;

        [HideInInspector]
        public List<GameObject> inRadiusEnemies;

        [HideInInspector]
        public SpriteRenderer radiusCircle;

        private BaseStats stats;

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
    }
}
