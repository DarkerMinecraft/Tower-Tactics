using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{

    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private float timeBetweenShoot;

    private float timeBetweenShootTimer; 

    void Start()
    {
        
    }

    void Update()
    {
        timeBetweenShootTimer += Time.deltaTime;

        if (timeBetweenShoot <= timeBetweenShootTimer) 
        {
            if (GetComponent<TowerController>().inRadiusEnemies.Count != 0)
            {
                GameObject projectile = Instantiate(this.projectile, transform);
                projectile.GetComponent<ProjectileMovement>().MoveTo(GetComponent<TowerController>().inRadiusEnemies[0]);
                timeBetweenShootTimer = 0;
            }
        }
    }
}
