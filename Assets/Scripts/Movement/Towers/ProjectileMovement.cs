using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed, rotationSpeed;

    private GameObject target;

    void Start()
    {
        
    }

    void Update()
    {
        if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);

            Vector3 direction = target.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward) * Quaternion.identity;
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
        else Destroy(gameObject);
    }

    public void MoveTo(GameObject target) { this.target = target; }
}
