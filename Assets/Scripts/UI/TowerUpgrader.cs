using System.Collections;
using System.Collections.Generic;
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

        private Dictionary<GameObject, int> currentUpgrade;

        private bool canUpgrade;

        public static bool onUI = false;

        private void Start()
        {
            currentUpgrade = new Dictionary<GameObject, int>();
            canUpgrade = true;
        }

        public void OnClick() 
        {
            Upgrade upgrade = upgraders[currentUpgrade[tower]];

            if (CoinsChanger.CanChangeCoins(upgrade.Cost) && canUpgrade) 
            {
                TowerStats towerStats = tower.GetComponent<TowerStats>();

                towerStats.AddAdditiveModifer(upgrade.Stat, upgrade.Addition);
                towerStats.AddPercentageModifer(upgrade.Stat, upgrade.Percentage);

                CoinsChanger.ChangeCoins(-upgrade.Cost);

                currentUpgrade[tower]++;
                if (currentUpgrade[tower] >= upgraders.Length)
                {
                    canUpgrade = false;
                    GetComponentInChildren<TextMeshProUGUI>().text = "Upgrade Path Complete";
                    cost.text = "";
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
            GetComponentInChildren<TextMeshProUGUI>().text = upgraders[currentUpgrade[tower]].UpgradeName;
            cost.text = "$" + upgraders[currentUpgrade[tower]].Cost.ToString("N0");
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            onUI = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            onUI = false;
        }
    }
}