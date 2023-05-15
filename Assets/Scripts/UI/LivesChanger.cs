using System.Collections;
using TMPro;
using UnityEngine;

namespace Tactics.UI
{

    public class LivesChanger : MonoBehaviour
    {

        private static int lives = 200;

        private TextMeshProUGUI text;

        private static GameObject gameOverObj;

        [HideInInspector]
        public static bool isGameOver = false;

        void Awake()
        {
            text = GetComponent<TextMeshProUGUI>();

            gameOverObj = GameObject.FindGameObjectWithTag("Game Over");
        }

        void Update()
        {
            text.text = lives.ToString("N0");
        }

        public static void DecreaseLives(int amount)
        {
            lives -= amount;

            if (lives <= 0)
            {
                gameOverObj.SetActive(true);
                isGameOver = true;
            }
            lives = Mathf.Clamp(lives, 0, lives);
        }

        public static void SetLives(int amount) { lives = amount; }
    }
}


