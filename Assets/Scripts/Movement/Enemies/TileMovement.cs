using Tactics.Stats;
using Tactics.UI;
using UnityEngine;

namespace Tactics.Movement.Enemies
{

    public class TileMovement : MonoBehaviour
    {

        [HideInInspector]
        public WaypointPath path;

        [SerializeField]
        [Range(0, 10)]
        private float rotationSpeed;

        [SerializeField]
        public int currentWaypoint;

        private BaseStats baseStats;

        private void Awake()
        {
            baseStats = GetComponent<BaseStats>();
        }

        void Start()
        {
            currentWaypoint = 0;
        }

        void Update()
        {
            if (currentWaypoint == 0)
            {
                transform.position = path.GetPath()[currentWaypoint];
                currentWaypoint++;
            }

            Vector2 waypoint = path.GetPath()[currentWaypoint];
            float distance = Vector2.Distance(transform.position, waypoint);

            Vector2 direction = (waypoint - (Vector2)transform.position);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

            transform.position = Vector2.MoveTowards(transform.position, waypoint, baseStats.GetStat(Stat.Speed) * Time.deltaTime);

            if (distance <= 0.001f)
            {
                currentWaypoint++;

                if (currentWaypoint >= path.GetPath().Length)
                {
                    LivesChanger.DecreaseLives(1);
                    Destroy(gameObject);
                }
            }
        }
    }
}