using System.Collections;
using System.Collections.Generic;
using Tactics.Stats;
using UnityEngine;

namespace Tactics.Towers.Upgrader
{
    public class TowerStats : MonoBehaviour, IModifierProvider
    {

        private Dictionary<Stat, float> additive, percentage;

        void Awake() 
        {
            additive = new Dictionary<Stat, float>();
            percentage = new Dictionary<Stat, float>();
        }

        public IEnumerable<float> GetAdditiveModifers(Stat stat)
        {
            if(additive.ContainsKey(stat)) 
                yield return additive[stat];
            else
                yield return 0;
        }

        public IEnumerable<float> GetPercentageModifers(Stat stat)
        {
            if (percentage.ContainsKey(stat))
                yield return percentage[stat];
            else
                yield return 0;
        }

        public void AddAdditiveModifer(Stat stat, float value) 
        {
            if(additive.ContainsKey(stat)) 
                additive[stat] += value;
            else additive.Add(stat, value);
        }
        public void AddPercentageModifer(Stat stat, float value) 
        {
            if(percentage.ContainsKey(stat))
                percentage[stat] += value; 
            else percentage.Add(stat, value);
        }
    }
}