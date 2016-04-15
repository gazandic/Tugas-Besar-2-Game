using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.// The audio clip to play when the player dies.

    public Slider healthSlider;                                 // Reference to the UI's health bar.
    public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt
    public Image gameOverImage;                                   // Reference to an image to flash on the screen on being hurt
    public Text  gameOverText;                                   // Reference to an image to flash on the screen on being hurt
    public AudioSource DeathSound;
    public AudioSource ZombieDamage;
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.
    public Color lol = new Color(01f, 0f, 0f, 1f);     // The colour the damageImage is set to, to flash.
    // Reference to the AudioSource component.
    UnityStandardAssets.Characters.FirstPerson.FirstPersonController playerMovement;   // Reference to the player's movement.
    Shoot playerShooting;                              // Reference to the PlayerShooting script.
    bool isDead;                                                // Whether the player is dead.
    bool damaged;                                               // True when the player gets damaged.


    void Awake()
    {
        // Setting up the references.
        playerMovement = GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        playerShooting = GetComponentInChildren<Shoot>();
        // Set the initial health of the player.
        currentHealth = startingHealth;
    }


    void Update()
    {
        if (damaged)
        {
            // ... set the colour of the damageImage to the flash colour.
            damageImage.color = flashColour;
        }
        // Otherwise...
        else
        {
            // ... transition the colour back to clear.
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        // Reset the damaged flag.
        damaged = false;
    }


    public void TakeDamage(int amount)
    {
        // Set the damaged flag so the screen will flash.
        damaged = true;

        // Reduce the current health by the damage amount.
        currentHealth -= amount;

        healthSlider.value = currentHealth;
        ZombieDamage.Play();
        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            StartCoroutine(Death()); 
        }
    }


    IEnumerator Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;
        // Turn off any remaining shooting effects.
        //playerShooting.DisableEffects();
        // Turn off the movement and shooting scripts.
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        playerShooting.enabled = false;
        playerMovement.enabled = false;
        gameOverImage.color = lol;
        DeathSound.Play();
        gameOverText.color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
        Application.LoadLevel("MainMenu");
    }
}