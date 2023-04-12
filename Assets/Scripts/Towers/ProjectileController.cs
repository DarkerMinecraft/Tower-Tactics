using System.Collections;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") 
        {
            Health health = collision.GetComponent<Health>();
            health.RemoveHealth(1);

            Destroy(gameObject);
        }
    }
}
