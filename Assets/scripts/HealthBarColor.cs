using UnityEngine;
using UnityEngine.UI;

public class HealthBarColor : MonoBehaviour
{
    public Image fill;

    public float maxHealth = 100f;
    public float currentHealth;

    public float smoothSpeed = 5f;

    void Start()
    {
        currentHealth = maxHealth;
        fill.fillAmount = 1f;
    }

    void Update()
    {
        float targetFill = currentHealth / maxHealth;

        // Smooth animation
        fill.fillAmount = Mathf.Lerp(fill.fillAmount, targetFill, Time.deltaTime * smoothSpeed);

        // Color change based on health
        if (targetFill > 0.7f)
            fill.color = Color.green;
        else if (targetFill > 0.3f)
            fill.color = Color.yellow;
        else
            fill.color = Color.red;
    }

    // Call this when player takes damage
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    // Optional heal function
    public void Heal(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }
}