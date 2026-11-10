using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform player;

    [SerializeField] private float aggroRange = 5f;
    [SerializeField] private float aggroSpeed = 6f;

    [SerializeField] private float normalSpeed = 3f;

    private Rigidbody2D rb;
    private bool isAggro = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        isAggro = distance <= aggroRange;
    }

    private void FixedUpdate()
    {
        if (isAggro)
        {
            float directionX = Mathf.Sign(player.position.x - rb.position.x);

            Vector2 velocity = rb.linearVelocity;
            velocity.x = directionX * aggroSpeed;

            rb.linearVelocity = velocity;
        }
        else
        {
            Vector2 velocity = rb.linearVelocity;
            velocity.x = 0f;

            rb.linearVelocity = velocity;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }
}
