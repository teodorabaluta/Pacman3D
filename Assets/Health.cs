using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth; // Maximum health of the player
    private int currentHealth; // Current health of the player

    public Image[] hearts; // Array of UI images representing hearts
    public Sprite fullHeart; // Sprite for a full heart
    public Sprite emptyHeart; // Sprite for an empty heart

    void Start()
    {
        currentHealth = maxHealth; // Set current health to maximum health initially
        UpdateHeartsUI(); // Update the UI to reflect initial health
    }

    // Method to decrease player's health when hit by an enemy (e.g., a ghost)
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Decrease current health by the specified damage amount

        // Ensure current health does not go below 0
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        UpdateHeartsUI(); // Update the UI to reflect the new health after taking damage
    }

    // Method to update the hearts UI based on the current health
    void UpdateHeartsUI()
    {
        // Loop through all hearts and update their sprites based on current health
        for (int i = 0; i < hearts.Length; i++)
        {
            // If the index is less than current health, display a full heart
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            // Otherwise, display an empty heart
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            // Enable or disable the heart image based on whether it's within the maximum health
            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
