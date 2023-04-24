using Tactics.Stats;
using UnityEngine;

namespace Tactics.Movement.Towers
{
    public class ProjectileMovement : MonoBehaviour
    {

        [SerializeField]
        private float rotationSpeed;

        private GameObject target;

        private BaseStats baseStats;

        private void Awake()
        {
            baseStats = GetComponent<BaseStats>();
        }

        void Update()
        {
            if (target != null)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, baseStats.GetStat(Stat.Speed) * Time.deltaTime);

                Vector3 direction = target.transform.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward) * Quaternion.identity;
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
            }
            else Destroy(gameObject);
        }

        public void MoveTo(GameObject target) { this.target = target; }
    }
}
