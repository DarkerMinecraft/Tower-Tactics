using System.Collections;
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
        private int cost;

        [SerializeField]
        private TowerPlacer towerPlacer;

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
