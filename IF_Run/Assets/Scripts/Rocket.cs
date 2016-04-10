using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {
    public int damagePerShot = 20;
    public float speed = 2000.0f;
    public GameObject explosionPrefab;
    void OnCollisionEnter(Collision c)
    {
        
        Instantiate(explosionPrefab,
                    transform.position,
                    Quaternion.identity);
        if (c.gameObject.tag == "Monster")
        {
            ZombieHealth enemyHealth = c.gameObject.GetComponent<ZombieHealth>();
            // If the EnemyHealth component exist...
            if (enemyHealth != null)
            {
                // ... the enemy should take damage.
                enemyHealth.TakeDamage(damagePerShot);
            }
        }

        Destroy(gameObject);
    }
    
}