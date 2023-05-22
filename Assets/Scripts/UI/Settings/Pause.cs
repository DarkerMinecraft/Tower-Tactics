using System.Collections;
using System.Collections.Generic;
using Tactics.UI;
using UnityEngine;

namespace Tactics
{
    public class Pause : MonoBehaviour
    {
        [SerializeField]
        private GameObject settingsObj;

        void Update()
        {
            if (settingsObj.activeSelf) return;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                settingsObj.SetActive(true);
                LivesChanger.isMenuUp = true;
            }
        }
    }
}
