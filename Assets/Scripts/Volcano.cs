using UnityEngine;

public class Volcano : MonoBehaviour
{

    public float health = 100f;
    private float maxHealth;
    public GameObject hitbox;
    public GameObject playerSpawn;

    private void Start()
    {
        maxHealth = health;
    }

    public void TakeDamage(float damage)
    {
        health = Mathf.Clamp(health - damage, 0, maxHealth);

        print("Volcano health: " + health);
    }
}