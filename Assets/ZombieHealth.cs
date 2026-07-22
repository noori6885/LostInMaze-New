using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public int health = 50;

    public void TakeDamage(int damage)
    {
        health -= damage;

        Debug.Log("Zombie Health : " + health);

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}