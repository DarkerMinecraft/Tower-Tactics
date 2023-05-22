using System.Collections;
using Tactics.Stats;
using Tactics.Towers;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tactics.UI
{

    public class TowerBuyer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {

        [SerializeField]
        private GameObject obj;

        [SerializeField]
        private Tower tower;

        [SerializeField]
        private TowerPlacer towerPlacer;

        private int cost;

        public static bool onUI = false;

        public void OnClick()
        {
            if (LivesChanger.isMenuUp) return;

            if (!towerPlacer.gameObject.GetComponent<TowerPicker>().enabled) return;

            for (int i = 0; i < towerPlacer.transform.childCount; i++)
            {
                towerPlacer.transform.GetChild(i).GetComponent<TowerController>().radiusCircle.enabled = false;
            }


            if (CoinsChanger.CanChangeCoins(cost))
            {
                towerPlacer.CreateTower(obj, cost);
            }

            towerPlacer.gameObject.GetComponent<TowerPicker>().enabled = false;
        }

        void Update() 
        {
            cost = TowerPricing.GetTowerPrice(tower);
            GetComponentInChildren<TextMeshProUGUI>().text = "$" + cost.ToString("N0");
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
