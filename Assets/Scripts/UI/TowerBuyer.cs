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
        private GameObject tower;

        [SerializeField]
        private TowerPlacer towerPlacer;

        [SerializeField]
        private int cost;

        public static bool onUI = false;

        private void Start()
        {
            GetComponentInChildren<TextMeshProUGUI>().text = "$" + cost.ToString("N0");
        }

        public void OnClick()
        {
            if (CoinsChanger.CanChangeCoins(cost))
            {
                towerPlacer.CreateTower(tower, cost);
            }

            towerPlacer.gameObject.GetComponent<TowerPicker>().enabled = false;
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
