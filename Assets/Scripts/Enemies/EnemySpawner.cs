using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private WaypointPath path;

    [SerializeField]
    private GameObject[] enemies;

    void Start()
    {
        foreach (GameObject enemy in enemies)
            enemy.GetComponent<TileMovement>().path = path;

        Instantiate(enemies[0], transform);
    }

    void Update()
    {
        
    }
}
