using UnityEngine;

public class Lava : MonoBehaviour
{

    public float damageAmount = 10f;

    private SFXManager sfxManager;

    private void Start()
    {
        sfxManager = FindFirstObjectByType<SFXManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if (player != null)
            {
                player.TakeDamage(damageAmount);
                sfxManager.PlayMeteorHit();
            }
        }
    }
}
