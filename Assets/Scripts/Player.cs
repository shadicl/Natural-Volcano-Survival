using UnityEngine;

public class Player : MonoBehaviour
{

    private float moveAmount;
    [SerializeField] private float moveSpeed = 10f;

    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float maxHealth = 100f;
    private float health;

    [SerializeField] private HealthBar healthBar;

    private bool isGrounded;

    private Rigidbody2D rb;

    float horizontal;
    float vertical;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        health = maxHealth;
        healthBar.UpdateHealth(health, maxHealth);
    }

    void Update()
    {
        moveAmount = horizontal * moveSpeed * Time.deltaTime;
        transform.position += new Vector3(moveAmount, 0f, 0f);

        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer);

        if (Input.GetKey(KeyCode.A))
        {
            horizontal = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontal = 1f;
        }
        else
        {
            horizontal = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        healthBar.UpdateHealth(health, maxHealth);
    }
}
