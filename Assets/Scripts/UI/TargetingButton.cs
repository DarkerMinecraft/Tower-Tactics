using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Tactics.UI
{
    public class TargetingButton : MonoBehaviour
    {
        private static Dictionary<GameObject, int> targettingStatus;

        [HideInInspector]
        public GameObject tower;

        private void Start()
        {
            targettingStatus = new Dictionary<GameObject, int>();
        }

        public void onClick() 
        {
            targettingStatus[tower]++;
            if (targettingStatus[tower] >= 2)
                targettingStatus[tower] = 0;
        }

        private void Update()
        {
            if (tower == null) return;

            if (!targettingStatus.ContainsKey(tower))
                targettingStatus.Add(tower, 0);

            if (targettingStatus.ContainsKey(tower))
                DisplayTarget(targettingStatus[tower]);
            else
                DisplayTarget(0);
        }

        void DisplayTarget(int target) 
        {
            if (target == 0)
                GetComponentInChildren<TextMeshProUGUI>().text = "First";
            if (target == 1)
                GetComponentInChildren<TextMeshProUGUI>().text = "Last";
        }

        public static int GetTargeting(GameObject obj)
        {
            Debug.Log(targettingStatus.ContainsKey(obj));

            if (targettingStatus.ContainsKey(obj))
                return targettingStatus[obj];
            else return 0;
        }
    }
}