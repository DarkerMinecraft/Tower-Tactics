using UnityEngine;
using UnityEngine.EventSystems;

namespace Tactics.UI
{
    public class TowerInfoUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {

        [SerializeField]
        private GameObject towerUpgrades;

        public static bool onUI;

        void Start() 
        {
            onUI = false;
            towerUpgrades.SetActive(false);
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