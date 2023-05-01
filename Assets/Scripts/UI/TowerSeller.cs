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
            CoinsChanger.ChangeCoins((int)discountedReturn);

            RemoveUpgrades();

            transform.parent.gameObject.SetActive(false);

            Destroy(tower);
        }

        private void Update()
        {
            if (tower == null) return;

            discountedReturn = (float)GetTotalCost() * .7f;
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

            return upgradeCost + (int)tower.GetComponent<BaseStats>().GetStat(Stat.BaseCost);
        }

        void RemoveUpgrades() 
        {
            TowerUpgrader[] towerUpgraders = transform.parent.GetComponentsInChildren<TowerUpgrader>();

            for (int i = 0; i < towerUpgraders.Length; i++)
            {
                TowerUpgrader tu = towerUpgraders[i];

                tu.RemoveTower(tower);
            }
        }

    }
}