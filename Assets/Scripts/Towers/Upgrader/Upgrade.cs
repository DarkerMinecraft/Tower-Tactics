using System.Collections;
using System.Collections.Generic;
using Tactics.Stats;
using UnityEngine;

namespace Tactics.Towers.Upgrader
{
    [CreateAssetMenu(fileName = "upgrade", menuName = "Tactics/Tower Upgrade", order = 1)]
    public class Upgrade : ScriptableObject
    {
        [SerializeField]
        private string upgradeName;
        [SerializeField]
        private string description;

        [SerializeField]
        private Stat stat;

        [SerializeField]
        private float percentage;
        [SerializeField]
        private float addition;

        [SerializeField]
        private int cost;

        public string UpgradeName { get => upgradeName; set => upgradeName = value; }
        public string Description { get => description; set => description = value; }
        public Stat Stat { get => stat; set => stat = value; }
        public int Cost { get => cost; set => cost = value; }
        public float Addition { get => addition; set => addition = value; }
        public float Percentage { get => percentage; set => percentage = value; }
    }
}
