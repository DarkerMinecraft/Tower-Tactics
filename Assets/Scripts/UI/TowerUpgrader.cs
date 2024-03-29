﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Tactics.Towers.Upgrader;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tactics.UI
{
    public class TowerUpgrader : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [HideInInspector]
        public Upgrade[] upgraders;
        [HideInInspector]
        public GameObject tower;

        [SerializeField]
        private TextMeshProUGUI cost;

        [SerializeField]
        private GameObject desciption;

        [SerializeField]
        private TowerUpgrader otherUpgrader;

        [HideInInspector]
        public Dictionary<GameObject, int> currentUpgrade;

        private bool canUpgrade;

        private Dictionary<GameObject, int> towerCost;

        private void Start()
        {
            currentUpgrade = new Dictionary<GameObject, int>();
            towerCost = new Dictionary<GameObject, int>();

            canUpgrade = true;
        }

        public void OnClick()
        {

            if (LivesChanger.isMenuUp) return;

            if (currentUpgrade[tower] >= upgraders.Length)
            {
                canUpgrade = false;
                GetComponentsInChildren<TextMeshProUGUI>()[0].text = "Upgrade Path Complete";
                cost.text = "";
            }

            if (!canUpgrade) return;

            int index = currentUpgrade[tower];

            if (index < upgraders.Length)
            {
                Upgrade upgrade = upgraders[index];

                if (CoinsChanger.CanChangeCoins(upgrade.Cost) && canUpgrade)
                {
                    TowerStats towerStats = tower.GetComponent<TowerStats>();

                    towerStats.AddAdditiveModifer(upgrade.Stat, upgrade.Addition);
                    towerStats.AddPercentageModifer(upgrade.Stat, upgrade.Percentage);

                    CoinsChanger.ChangeCoins(-upgrade.Cost);
                    if (!towerCost.ContainsKey(tower))
                        towerCost.Add(tower, 0);
                    towerCost[tower] += upgrade.Cost;

                    currentUpgrade[tower]++;
                }
            }
        }

        private void Update()
        {
            if (tower == null) return;

            if (!currentUpgrade.ContainsKey(tower))
                currentUpgrade.Add(tower, 0);

            if (currentUpgrade[tower] < upgraders.Length) canUpgrade = true;
            if (!canUpgrade) return;

            UpdateButton();
        }

        void UpdateButton()
        {
            int index = currentUpgrade[tower];

            if (index < upgraders.Length)
            {
                Upgrade upgrade = upgraders[index];

                GetComponentsInChildren<TextMeshProUGUI>()[0].text = upgrade.UpgradeName;
                cost.text = "$" + upgrade.Cost.ToString("N0");
            }
            else 
            {
                GetComponentsInChildren<TextMeshProUGUI>()[0].text = "Upgrade Path Complete";
                cost.text = "";

                canUpgrade = false;
            }
        }

        public int GetUpgradeCost(GameObject tower)
        {
            if(towerCost.ContainsKey(tower))
                return towerCost[tower]; 
            else return 0;
        }

        public void RemoveTower(GameObject tower)
        {
            if(currentUpgrade.ContainsKey(tower))
                currentUpgrade.Remove(tower);

            if(towerCost.ContainsKey(tower))
                towerCost.Remove(tower);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            int index = currentUpgrade[tower];
            if (index >= upgraders.Length) return;

            desciption.SetActive(true);
            desciption.GetComponentInChildren<TextMeshProUGUI>().text = upgraders[currentUpgrade[tower]].Description;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            desciption.SetActive(false);
        }
    }
}