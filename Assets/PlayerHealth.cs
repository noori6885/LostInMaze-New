using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth = 100;
    public int currentHealth;

    [Header("UI")]
    public Slider healthSlider;
    public Image fillImage;

    [Header("Health Colors")]
    public Color fullHealthColor = Color.green;
    public Color halfHealthColor = Color.yellow;
    public Color lowHealthColor = Color.red;

    private void Start()
    {
        currentHealth = maxHealth;

        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;

        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth < 0)
            currentHealth = 0;

        UpdateHealthBar();

        Debug.Log("Player Health : " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthBar()
    {
        healthSlider.value = currentHealth;

        float percent = (float)currentHealth / maxHealth;

        if (percent > 0.5f)
            fillImage.color = fullHealthColor;
        else if (percent > 0.2f)
            fillImage.color = halfHealthColor;
        else
            fillImage.color = lowHealthColor;
    }

    void Die()
    {
        Debug.Log("GAME OVER");

        // Future me Game Over panel yahan show karenge.
    }
}