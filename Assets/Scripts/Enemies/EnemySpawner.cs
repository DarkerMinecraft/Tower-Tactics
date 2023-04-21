using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    private const float A_10 = 30f;
    private const float A_30 = 100f;
    private const float A_50 = 300f;
    private const float A_100 = 1000f;
    private const float A_1000 = 10000f;
    private const float B = 0.0141f;

    [SerializeField]
    private WaypointPath path;
    [SerializeField]
    private GameObject[] enemies;

    private bool playing;

    private int waveCounter;
    private int enemyCount;

    private bool coroutineFinished;

    void Start()
    {
        playing = false;
        waveCounter = 0;

        foreach (GameObject enemy in enemies)
            enemy.GetComponent<TileMovement>().path = path;

        coroutineFinished = false;
    }

    IEnumerator StartWave() 
    {
        for (int i = 0; i < enemyCount; i++) 
        {
            int enemyIndex = Random.Range(0, enemies.Length);
            GameObject enemy = enemies[enemyIndex];
            Instantiate(enemy, transform);

            yield return new WaitForSeconds(0.3f);
        }

        coroutineFinished = true;
    }

    public void CreateWave() 
    {
        waveCounter++;
        playing = true;

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

        enemyCount = (int) (a * Mathf.Exp(B * waveCounter));

        StartCoroutine("StartWave");
    }

    private void Update()
    {
        if (transform.childCount == 0 && coroutineFinished)
        {
            playing = false;
            coroutineFinished = false;

            CoinsChanger.ChangeCoins(100);
        }

        WaveCounter.SetWaveCounter(waveCounter);

    }

    public bool IsPlaying() { return playing; }
}
