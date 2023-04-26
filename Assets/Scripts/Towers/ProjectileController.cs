using System.Collections;
using System.Collections.Generic;
using Tactics.Attributes;
using Tactics.Stats;
using Tactics.UI;
using UnityEngine;

namespace Tactics.Towers
{
    public class ProjectileController : MonoBehaviour, IModifierProvider
    {

        private BaseStats baseStats;

        private void Awake()
        {
            baseStats = GetComponentInParent<BaseStats>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Enemy")
            {
                Health health = collision.GetComponent<Health>();
                health.RemoveHealth(baseStats.GetStat(Stat.Damage));

                Destroy(gameObject);
            }
        }

        public IEnumerable<float> GetAdditiveModifers(Stat stat)
        {
            yield return 0;
        }

        public IEnumerable<float> GetPercentageModifers(Stat stat)
        {
            if (stat == Stat.Speed && PlayButton.IsFast())
                yield return 100;
        }

    }
}
