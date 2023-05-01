using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tactics.Assets.Scripts.UI
{
    public class TowerInfoUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {

        public static bool onUI;

        void Start() 
        {
            onUI = false;
            gameObject.SetActive(false);
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