using UnityEngine;
using System.Collections;

public class ZombieHealth : MonoBehaviour {
    public int startingHealth = 100;            // The amount of health the enemy starts the game with.
    public int currentHealth;                   // The current health the enemy has.
    public float sinkSpeed = 2.5f;              // The speed at which the enemy sinks through the floor when dead.
    public int scoreValue = 10;                 // The amount added to the player's score when the enemy dies.

    CapsuleCollider capsuleCollider;            // Reference to the capsule collider.
    bool isDead;                                // Whether the enemy is dead.


    void Awake ()
    {
        capsuleCollider = GetComponent <CapsuleCollider>();

        // Setting the current health when the enemy first spawns.
        currentHealth = startingHealth;
    }

    void Update ()
    {
       
    }


    public void TakeDamage (int amount)
    {
        // If the enemy is dead...
        if(isDead)
            // ... no need to take damage so exit the function.
            return;

        
        // Reduce the current health by the amount of damage sustained.
        currentHealth -= amount;
            
        // If the current health is less than or equal to zero...
        if(currentHealth <= 0)
        {
            // ... the enemy is dead.
            Death ();
        }
    }


    void Death ()
    {
        // The enemy is dead.
        isDead = true;

        // Turn the collider into a trigger so shots can pass through it.
        capsuleCollider.isTrigger = true;

        // Increase the score by the enemy's score value.
        ScoreManager.score += scoreValue;

        // After 2 seconds destory the enemy.
        Destroy(gameObject);

    }


}
