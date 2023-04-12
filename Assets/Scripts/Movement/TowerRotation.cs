using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRotation : MonoBehaviour
{

    [SerializeField]
    private float radius;

    [SerializeField]
    [Range(0, 90)]
    private float rotationSpeed;

    [SerializeField]
    private EnemySpawner spawner;

    private List<GameObject> inRadiusEnemies;

    private Quaternion startingRotation;

    void Start()
    {
        inRadiusEnemies = new List<GameObject>();

        startingRotation = transform.rotation;
    }

    void Update()
    {
        for (int i = 0; i < spawner.transform.childCount; i++) 
        {
            Transform spawnerChild = spawner.transform.GetChild(i);

            float distance = Vector2.Distance(spawnerChild.position, transform.position);

            if (!inRadiusEnemies.Contains(spawnerChild.gameObject))
            {
                if (distance <= radius)
                    inRadiusEnemies.Add(spawnerChild.gameObject);
            }
            else 
            {
                if(distance > radius) 
                    inRadiusEnemies.Remove(spawnerChild.gameObject);
            }
        }

        if (inRadiusEnemies.Count != 0)
        {
            Vector3 direction = inRadiusEnemies[0].transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward) * Quaternion.identity;
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
        else transform.rotation = Quaternion.Slerp(transform.rotation, startingRotation, rotationSpeed * Time.deltaTime);


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
