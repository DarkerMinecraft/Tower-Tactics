using System.Collections;
using System.Collections.Generic;
using Tactics.Movement.Enemies;
using Tactics.UI;
using UnityEngine;

namespace Tactics.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {

        private const float A_10 = 20f;
        private const float A_30 = 100f;
        private const float A_50 = 300f;
        private const float A_100 = 1000f;
        private const float A_1000 = 10000f;
        private const float B = 0.0141f;

        [SerializeField]
        private WaypointPath[] paths;
        [SerializeField]
        private GameObject[] enemies;

        [SerializeField]
        private float enemySpawnRate = 0.6f;

        private bool playing;

        private static int waveCounter;
        private int enemyCount;

        private bool coroutineFinished;

        private static List<GameObject> allowedEnemies;

        private static GameObject firstEnemy;

        [HideInInspector]
        public static bool isFreePlay = false;

        private GameObject winGameObj; 

        void Start()
        {
            playing = false;
            waveCounter = 0;
            allowedEnemies = new List<GameObject>();
            coroutineFinished = false;

            firstEnemy = enemies[0];    

            allowedEnemies.Add(firstEnemy);

            winGameObj = GameObject.FindGameObjectWithTag("Win");
        }

        IEnumerator StartWave()
        {   
            
            for (int i = 0; i < enemyCount; i++)
            {
                GameObject enemy = allowedEnemies[Random.Range(0, allowedEnemies.Count)];
                enemy.GetComponent<TileMovement>().path = paths[Random.Range(0, paths.Length)];
                Instantiate(enemy, transform);

                yield return new WaitForSeconds(PlayButton.IsFast() ? enemySpawnRate / 2 : enemySpawnRate);
            }

            coroutineFinished = true;
        }

        public void CreateWave()
        {
            waveCounter++;
            playing = true;

            if (waveCounter == 50 && !isFreePlay) 
            {
                LivesChanger.isMenuUp = true;
                winGameObj.SetActive(true);
                return;
            }

            float a = 0;

            if (waveCounter <= 10)
            {
                a = A_10 / Mathf.Exp(B * 10);
            }
            else if (waveCounter <= 30)
            {
                a = A_30 / Mathf.Exp(B * 30);
            }
            else if (waveCounter <= 50)
            {
                a = A_50 / Mathf.Exp(B * 50);
            }
            else if (waveCounter <= 100)
            {
                a = A_100 / Mathf.Exp(B * 100);
            }
            else
            {
                a = A_1000 / Mathf.Exp(B * 1000);
            }

            enemyCount = (int)(a * Mathf.Exp(B * waveCounter));

            if (waveCounter == 3)
                allowedEnemies.Add(enemies[1]);
            else if(waveCounter == 9)
                allowedEnemies.Add(enemies[2]);
            

            StartCoroutine("StartWave");
        }

        private void Update()
        {
            if (transform.childCount == 0 && coroutineFinished)
            {
                playing = false;
                coroutineFinished = false;

                CoinsChanger.ChangeCoins(Random.Range(100, 151));
            }

            WaveCounter.SetWaveCounter(waveCounter);

        }

        public bool IsPlaying() { return playing; }
        public static int GetWave() { return waveCounter; }

        private static void SetWaveCounter(int wave) { waveCounter = wave; }

        public static void ResetSpawner() 
        {
            SetWaveCounter(0);
            allowedEnemies.Clear();

            allowedEnemies.Add(firstEnemy);
        }
    }
}