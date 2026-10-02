using UnityEngine;

public class Volcano : MonoBehaviour
{

    public float maxHealth = 100f;
    private float health;
    public GameObject hitbox;
    public GameObject playerSpawn;

    [SerializeField] private HealthBar healthBar;

    private void Start()
    {
        health = maxHealth;
        healthBar.UpdateHealth(health, maxHealth);
    }

    public void TakeDamage(float damage)
    {
        health = Mathf.Clamp(health - damage, 0, maxHealth);
        healthBar.UpdateHealth(health, maxHealth);

        print("Volcano health: " + health);
    }
}