using System.Collections;
using TMPro;
using UnityEngine;

namespace Tactics.UI
{

    public class LivesChanger : MonoBehaviour
    {

        private static int lives = 200;

        private TextMeshProUGUI text;

        void Awake()
        {
            text = GetComponent<TextMeshProUGUI>();
        }

        void Update()
        {
            text.text = lives.ToString("N0");
        }

        public static void DecreaseLives(int amount)
        {
            lives -= amount;
        }
    }
}


