using System.Collections;
using System.Collections.Generic;
using Tactics.Towers;
using Tactics.UI;
using UnityEngine;

namespace Tactics.Movement.Towers
{
    public class TowerRotation : MonoBehaviour
    {

        [SerializeField]
        [Range(0, 90)]
        private float rotationSpeed;

        private List<GameObject> inRadiusEnemies;

        private Quaternion startingRotation;

        private TowerController towerController;

        void Start()
        {
            startingRotation = transform.rotation;
            towerController = transform.parent.GetComponent<TowerController>();
        }

        void LateUpdate()
        {
            inRadiusEnemies = towerController.inRadiusEnemies;

            if (inRadiusEnemies.Count != 0)
            {
                GameObject target = GetProjectileTarget();
                if (target != null)
                {
                    Vector3 direction = target.transform.position - transform.position;
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
                    Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward) * Quaternion.identity;
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
                }
                else transform.rotation = Quaternion.Slerp(transform.rotation, startingRotation, rotationSpeed * Time.deltaTime);
            }
            else transform.rotation = Quaternion.Slerp(transform.rotation, startingRotation, rotationSpeed * Time.deltaTime);


        }

        private GameObject GetProjectileTarget()
        {
            int targetType = TargetingButton.GetTargeting(transform.parent.gameObject);
            List<GameObject> enemies = inRadiusEnemies;

            if (targetType == 0)
            {
                return enemies[0];
            }
            else if (targetType == 1)
            {
                return enemies[enemies.Count - 1];
            }
            else return null;
        }

    }
}
