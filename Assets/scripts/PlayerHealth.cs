using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth = 100;
    private int currentHealth;

    [Header("UI")]
    public Slider healthSlider;
    public Image fillImage;

    [Header("Game Over")]
    public GameObject gameOverPanel;

    [Header("Health Colors")]
    public Color fullHealthColor = Color.green;
    public Color halfHealthColor = Color.yellow;
    public Color lowHealthColor = Color.red;

    private bool isDead = false;

    private void Start()
    {
        currentHealth = maxHealth;

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }

        UpdateHealthBar();

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    // Player Damage
    public void TakeDamage(int damage)
    {
        if (isDead)
            return;

        currentHealth -= damage;

        if (currentHealth < 0)
            currentHealth = 0;

        Debug.Log("Player Health: " + currentHealth);

        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Player Heal
    public void Heal(int amount)
    {
        if (isDead)
            return;

        currentHealth += amount;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        Debug.Log("Player Healed: " + currentHealth);

        UpdateHealthBar();
    }

    // Update UI
    private void UpdateHealthBar()
    {
        if (healthSlider != null)
            healthSlider.value = currentHealth;

        if (fillImage != null)
        {
            float percent = (float)currentHealth / maxHealth;

            if (percent > 0.5f)
                fillImage.color = fullHealthColor;
            else if (percent > 0.2f)
                fillImage.color = halfHealthColor;
            else
                fillImage.color = lowHealthColor;
        }
    }

    // Game Over
    private void Die()
    {
        if (isDead)
            return;

        isDead = true;

        Debug.Log("GAME OVER");

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Current Health Getter
    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    // Check if Player is Dead
    public bool IsDead()
    {
        return isDead;
    }
}