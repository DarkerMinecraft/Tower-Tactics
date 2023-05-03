using System.Collections;
using System.Collections.Generic;
using Tactics.Attributes;
using Tactics.Stats;
using Tactics.UI;
using UnityEngine;

namespace Tactics.Towers
{
    [RequireComponent(typeof(LineRenderer))]
    public class LineConnecter : MonoBehaviour
    {
        private GameObject target;

        [SerializeField]
        private int numberOfPoints;

        [SerializeField]
        private int animationSpeed;

        private Vector2 currentPosition;

        private LineRenderer lineRenderer;

        private BaseStats stats;

        private float timeBetweenShootTimer = 0;

        private void Awake()
        {
            lineRenderer = GetComponent<LineRenderer>();
            stats = GetComponent<BaseStats>();
        }

        private void Update()
        {
            target = GetTarget();

            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(numberOfPoints - 1, target.transform.position);
            timeBetweenShootTimer += Time.deltaTime;

            if (stats.GetStat(Stat.ShootingTime) <= timeBetweenShootTimer)
            {
                if (GetComponent<TowerController>().inRadiusEnemies.Count != 0)
                {
                    lineRenderer.SetPosition(0, transform.position);
                    lineRenderer.SetPosition(numberOfPoints - 1, target.transform.position);
                    StartCoroutine(AnimateLighting());
                }
            }
        }

        IEnumerator AnimateLighting() 
        {
            for (int i = 1; i < numberOfPoints - 1; i++)
            {
                Vector2 position = transform.position;
                position.x += Random.Range(-1f, 1f);
                position.y += Random.Range(-1f, 1f);
                lineRenderer.SetPosition(i, position);
            }
            yield return new WaitForSeconds(animationSpeed);
            HitEnemy(); 
        }

        private GameObject GetTarget()
        {
            int targetType = TargetingButton.GetTargeting(transform.parent.gameObject);
            List<GameObject> enemies = transform.parent.GetComponent<TowerController>().inRadiusEnemies;

            if (targetType == 0)
            {
                return enemies[0];
            }
            else if (targetType == 1)
            {
                return enemies[enemies.Count - 1];
            }
            else return null;
        }

        void HitEnemy() 
        {
            target.GetComponent<Health>().RemoveHealth(stats.GetStat(Stat.Damage));
        }
    }
}