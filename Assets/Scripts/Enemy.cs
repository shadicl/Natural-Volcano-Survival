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
        float distance = Vector2.Distance(transform.position, player.position);

        isAggro = distance <= aggroRange;
    }

    private void FixedUpdate()
    {
        if (isAggro)
        {
            Vector2 direction = ((Vector2)player.position - rb.position).normalized;

            rb.MovePosition(rb.position + direction * aggroSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }
}
