using System.Collections;
using Tactics.Enemies;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tactics.UI
{

    public class PlayButton : MonoBehaviour
    {
        [SerializeField]
        private EnemySpawner enemySpawner;

        [SerializeField]
        private Color play, duringPlay;

        private static bool isFast;

        private void Start()
        {
            isFast = false;
        }

        public void OnClick()
        {
            if (LivesChanger.isGameOver) return;

            if (!enemySpawner.IsPlaying())
                enemySpawner.CreateWave();
            else
                isFast = !isFast;
        }

        private void Update()
        {
            if (enemySpawner.IsPlaying()) GetComponent<Button>().image.color = duringPlay;
            else GetComponent<Button>().image.color = play;

            string buttonText = isFast ? ">>" : ">";
            GetComponentInChildren<TextMeshProUGUI>().text = buttonText;
        }

        public static bool IsFast() { return isFast; } 

    }
}
