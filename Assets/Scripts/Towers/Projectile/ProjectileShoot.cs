using System.Collections;
using System.Collections.Generic;
using Tactics.Movement.Towers;
using Tactics.Stats;
using Tactics.UI;
using UnityEngine;

namespace Tactics.Towers
{
    public class ProjectileShoot : MonoBehaviour
    {

        [SerializeField]
        private GameObject projectile;

        [SerializeField]
        private Transform shootPosition;

        private BaseStats stats;

        private float timeBetweenShootTimer;

        private void Awake()
        {
            stats = GetComponent<BaseStats>();
        }

        void Update()
        {
            timeBetweenShootTimer += Time.deltaTime;
            if (stats.GetStat(Stat.ShootingTime) <= timeBetweenShootTimer)
            {
                if (GetComponent<TowerController>().inRadiusEnemies.Count != 0)
                {
                    GameObject projectile = Instantiate(this.projectile, shootPosition == null ? transform : shootPosition);
                    SetProjectileTarget(projectile);
                    timeBetweenShootTimer = 0;
                }
            }
        }

        private void SetProjectileTarget(GameObject projectile)
        {
            int targetType = TargetingButton.GetTargeting(transform.parent.gameObject);
            List<GameObject> enemies = GetComponent<TowerController>().inRadiusEnemies;

            if (targetType == 0)
            {
                projectile.GetComponent<ProjectileMovement>().MoveTo(enemies[0]);
            }
            else if (targetType == 1)
            {
                projectile.GetComponent<ProjectileMovement>().MoveTo(enemies[enemies.Count - 1]);
            }
        }

    }
}
