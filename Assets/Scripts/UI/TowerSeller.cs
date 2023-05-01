using System.Collections;
using Tactics.Stats;
using TMPro;
using UnityEngine;

namespace Tactics.UI
{
    public class TowerSeller : MonoBehaviour
    {

        [HideInInspector]
        public GameObject tower;

        private float discountedReturn; 

        public void onClick() 
        {
           CoinsChanger.ChangeCoins((int) discountedReturn);
           Destroy(tower);
        }

        private void Update()
        {
           discountedReturn = (float) GetTotalCost() * .7f;
           GetComponentInChildren<TextMeshProUGUI>().text = "Sell: $" + discountedReturn.ToString("N0");
        }


        private int GetTotalCost() 
        {
            TowerUpgrader[] towerUpgraders = transform.parent.GetComponentsInChildren<TowerUpgrader>();

            int upgradeCost = 0;

            for (int i = 0; i < towerUpgraders.Length; i++) 
            {
                TowerUpgrader tu = towerUpgraders[i];

                upgradeCost += tu.GetUpgradeCost(tower);
            }

            return upgradeCost + (int) tower.GetComponent<BaseStats>().GetStat(Stat.BaseCost);
        }

    }
}