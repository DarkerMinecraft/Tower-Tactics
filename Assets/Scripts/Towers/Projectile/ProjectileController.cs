using System.Collections;
using System.Collections.Generic;
using Tactics.Attributes;
using Tactics.Movement.Towers;
using Tactics.Stats;
using Tactics.UI;
using UnityEngine;

namespace Tactics.Towers
{
    public class ProjectileController : MonoBehaviour
    {

        private BaseStats baseStats;

        private void Awake()
        {
            baseStats = GetComponentInParent<BaseStats>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject == GetComponent<ProjectileMovement>().GetTarget())
            {
                Health health = collision.GetComponent<Health>();
                health.RemoveHealth(baseStats.GetStat(Stat.Damage));

                Destroy(gameObject);
            }
        }

    }
}
