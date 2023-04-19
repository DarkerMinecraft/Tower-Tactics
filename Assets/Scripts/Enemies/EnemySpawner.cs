using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private WaypointPath path;

    [SerializeField]
    private GameObject[] enemies;

    private bool playing;

    void Start()
    {
        playing = false;

        foreach (GameObject enemy in enemies)
            enemy.GetComponent<TileMovement>().path = path;
    }

    public void StartWave() 
    {
        Instantiate(enemies[0], transform);
    }

    private void Update()
    {
        if (transform.childCount == 0) playing = false;
        else playing = true;
    }

    public bool IsPlaying() { return playing; }
}
