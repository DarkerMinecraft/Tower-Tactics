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

        private static bool fastForward = false;

        public void OnClick()
        {
            if (!enemySpawner.IsPlaying())
                enemySpawner.CreateWave();
            else
            {
                if (fastForward)
                {
                    fastForward = false;
                    GetComponentInChildren<TextMeshProUGUI>().text = ">";
                }
                else
                {
                    fastForward = true;
                    GetComponentInChildren<TextMeshProUGUI>().text = ">>";
                }
            }
        }

        private void Update()
        {
            if (enemySpawner.IsPlaying()) GetComponent<Button>().image.color = duringPlay;
            else GetComponent<Button>().image.color = play;
        }

        public static bool IsFast() { return fastForward; }
    }
}
