using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tactics.Stats
{
    public class BaseStats : MonoBehaviour
    {
        [SerializeField]
        private Stats[] stats;

        private Dictionary<Stat, float> dict = new Dictionary<Stat, float>();

        [System.Serializable]
        class Stats 
        {
            public Stat stat;
            public float baseValue;
        }

        public float GetStat(Stat stat) 
        {
            return (GetBaseStat(stat) + GetAdditiveModifier(stat)) * GetPercentageModifer(stat);
        }

        private float GetBaseStat(Stat stat) 
        {
            if (dict.Keys.Count == 0)
                LoadDictionary();

            return dict[stat];
        }

        private float GetAdditiveModifier(Stat stat)
        {
            float totalModifer = 0;

            foreach (IModifierProvider provider in GetComponents<IModifierProvider>())
            {
                foreach (float modifier in provider.GetAdditiveModifers(stat))
                    totalModifer += modifier;
            }
            return totalModifer;
        }

        private float GetPercentageModifer(Stat stat)
        {
            float totalModifer = 0;

            foreach (IModifierProvider provider in GetComponents<IModifierProvider>())
            {
                foreach (float modifier in provider.GetPercentageModifers(stat))
                    totalModifer += modifier;
            }
            return 1 + (totalModifer / 100f);
        }

        private void LoadDictionary() 
        {
            foreach(Stats stats in stats) 
            {
                dict[stats.stat] = stats.baseValue;
            }
        }
    }
}
