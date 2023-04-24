using System.Collections;
using System.Collections.Generic;
using Tactics.Enemies;
using UnityEngine;

namespace Tactics.Towers
{
    public class TowerController : MonoBehaviour
    {

        [SerializeField]
        private float radius;

        [HideInInspector]
        public EnemySpawner spawner;

        [HideInInspector]
        public List<GameObject> inRadiusEnemies;

        [HideInInspector]
        public SpriteRenderer radiusCircle;

        private void Awake()
        {
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
                        if (distance <= radius)
                            inRadiusEnemies.Add(spawnerChild.gameObject);
                    }
                    else
                    {
                        if (distance > radius)
                            inRadiusEnemies.Remove(spawnerChild.gameObject);
                    }
                }

                for (int i = 0; i < inRadiusEnemies.Count; i++)
                {
                    GameObject obj = inRadiusEnemies[i];
                    if (obj == null) inRadiusEnemies.Remove(obj);
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, radius);
        }

        public float GetRadius() { return radius; }
    }
}
