using UnityEngine;

public class VolcanoHitboxController : MonoBehaviour
{
    private Volcano volcano;
    public float damage = 20f;

    private void Awake()
    {
        volcano = GetComponentInParent<Volcano>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            volcano.TakeDamage(damage);
            collision.transform.position = volcano.playerSpawn.transform.position;
        }
    }
}
