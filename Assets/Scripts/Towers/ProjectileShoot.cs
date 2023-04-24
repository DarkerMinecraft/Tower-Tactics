using System.Collections;
using System.Collections.Generic;
using Tactics.Movement.Towers;
using Tactics.UI;
using UnityEngine;

namespace Tactics.Towers
{
    public class ProjectileShoot : MonoBehaviour
    {

        [SerializeField]
        private GameObject projectile;

        [SerializeField]
        private float timeBetweenShoot;

        private float timeBetweenShootTimer;

        void Update()
        {
            timeBetweenShootTimer += Time.deltaTime;

            if ((timeBetweenShoot / (PlayButton.IsFast() ? 2 : 1)) <= timeBetweenShootTimer)
            {
                if (GetComponent<TowerController>().inRadiusEnemies.Count != 0)
                {
                    GameObject projectile = Instantiate(this.projectile, transform);
                    projectile.GetComponent<ProjectileMovement>().MoveTo(GetComponent<TowerController>().inRadiusEnemies[0]);
                    timeBetweenShootTimer = 0;
                }
            }
        }
    }
}
