using System.Collections;
using Tactics.Towers.Upgrader;
using Tactics.UI;
using Tactics.Upgrader;
using UnityEngine;

namespace Tactics.Towers
{
    public class TowerPicker : MonoBehaviour
    {
        [SerializeField]
        private GameObject towerUpgraderUI;

        [SerializeField]
        private float searchRadius;

        [HideInInspector]
        public float towerDistance;

        [HideInInspector]
        public Upgrade[] upgradersPath1;
        [HideInInspector]
        public Upgrade[] upgradersPath2;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && !TowerUpgrader.onUI)
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Collider2D[] colliders = Physics2D.OverlapCircleAll(mousePosition, searchRadius);

                GameObject closestObject = null;
                float closestDistance = Mathf.Infinity;

                foreach (Collider2D collider in colliders)
                {
                    TowerController towerController = collider.GetComponent<TowerController>();
                    if (towerController != null)
                    {
                        float distance = Vector2.Distance(mousePosition, collider.transform.position);
                        if (distance < closestDistance)
                        {
                            closestObject = collider.gameObject;
                            closestDistance = distance;
                        }
                    }
                }

                if (closestObject != null)
                { 
                    upgradersPath1 = closestObject.GetComponent<TowerUpgrades>().path1;
                    upgradersPath2 = closestObject.GetComponent<TowerUpgrades>().path2;
                    ActiveUpgrade(true, closestObject);
                }
                else ActiveUpgrade(false, null);

            }
        }

        void ActiveUpgrade(bool activation, GameObject obj)
        {
            towerUpgraderUI.SetActive(activation);
            if (obj == null) return;

            if (activation)
            {
                TowerUpgrader[] upgraders = towerUpgraderUI.GetComponentsInChildren<TowerUpgrader>();
                for (int i = 0; i < upgraders.Length; i++)
                {
                    upgraders[i].tower = obj;
                }

                upgraders[0].upgraders = upgradersPath1;
                upgraders[1].upgraders = upgradersPath2;
            }

            obj.GetComponent<TowerController>().radiusCircle.enabled = activation;
        }
    }
}
