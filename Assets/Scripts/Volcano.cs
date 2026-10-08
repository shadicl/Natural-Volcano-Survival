using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Volcano : MonoBehaviour
{

    public float maxHealth = 100f;
    private float health;
    public GameObject hitbox;
    public GameObject playerSpawn;

    [SerializeField] private HealthBar healthBar;
    [SerializeField] private MeteorSpawner meteorSpawner;
    [SerializeField] private VictoryUI victoryUI;

    private void Start()
    {
        health = maxHealth;
        UpdateStatus();
    }

    public void TakeDamage(float damage)
    {
        health = Mathf.Clamp(health - damage, 0, maxHealth);
        UpdateStatus();

        print("Volcano health: " + health);
    }

    private void UpdateStatus()
    {

        Image bar = healthBar.image;

        healthBar.UpdateHealth(health, maxHealth);
        meteorSpawner.spawnRate -= 0.05f;

        if (health <= 0)
        {
            victoryUI.Enable();
        }
    }
}