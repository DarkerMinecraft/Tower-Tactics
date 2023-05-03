using System.Collections;
using Tactics.Stats;
using Tactics.Towers;
using TMPro;
using UnityEngine;

namespace Tactics.UI
{
    public class TowerSeller : MonoBehaviour
    {

        [HideInInspector]
        public GameObject obj;

        [HideInInspector]
        public Tower tower;

        private float discountedReturn;

        public void onClick()
        {
            CoinsChanger.ChangeCoins((int)discountedReturn);

            RemoveUpgrades();

            transform.parent.gameObject.SetActive(false);

            Destroy(obj);
        }

        private void Update()
        {
            if (obj == null) return;

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

                upgradeCost += tu.GetUpgradeCost(obj);
            }

            return upgradeCost + TowerPricing.GetTowerPrice(tower);
        }

        void RemoveUpgrades() 
        {
            TowerUpgrader[] towerUpgraders = transform.parent.GetComponentsInChildren<TowerUpgrader>();

            for (int i = 0; i < towerUpgraders.Length; i++)
            {
                TowerUpgrader tu = towerUpgraders[i];

                tu.RemoveTower(obj);
            }
        }

    }
}