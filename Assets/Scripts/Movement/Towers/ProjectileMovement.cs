using System.Collections.Generic;
using Tactics.Stats;
using Tactics.Towers;
using Tactics.UI;
using UnityEngine;

namespace Tactics.Movement.Towers
{
    public class ProjectileMovement : MonoBehaviour
    {

        [SerializeField]
        private float rotationSpeed;

        private GameObject target;

        private BaseStats baseStats;

        private void Awake()
        {
            baseStats = transform.GetComponentInParent<BaseStats>();
        }

        void Update()
        {
            if (target != null)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, baseStats.GetStat(Stat.Speed) * Time.deltaTime);

                Vector3 direction = target.transform.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward) * Quaternion.identity;
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
            }
            else SetProjectileTarget();
        }

        public void MoveTo(GameObject target) { this.target = target; }

        public GameObject GetTarget() { return target; }

        private void SetProjectileTarget()
        {
            int targetType = TargetingButton.GetTargeting(transform.parent.gameObject);
            List<GameObject> enemies = GetComponentInParent<TowerController>().inRadiusEnemies;

            if (targetType == 0)
            {
                MoveTo(enemies[0]);
            }
            else if (targetType == 1)
            {
                MoveTo(enemies[enemies.Count - 1]);
            }
        }
    }
}
