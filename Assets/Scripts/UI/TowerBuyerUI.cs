using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tactics.UI
{
    public class TowerBuyerUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {

        public static bool onUI;

        void Start()
        {
            onUI = false;
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