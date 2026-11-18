using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private float moveAmount;
    [SerializeField] private float moveSpeed = 10f;
    private float originalSpeed;

    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float maxHealth = 100f;
    private float health;

    [SerializeField] private float maxStamina = 100f;
    private float stamina;
    [SerializeField] private float staminaDrain = 100f;
    [SerializeField] private float sprintMultiplier = 2f;
    private float sprintSpeed;

    public float regenDelay = 2f;
    public float staminaRegenAmount = 0.5f;

    private float timer = 0f;

    [SerializeField] private HealthBar healthBar;
    [SerializeField] private SprintBar sprintBar;

    [SerializeField] private SFXManager sfxManager;

    [SerializeField] private Parry parryScript;
    public bool isParrying = false;
    public bool canParry = true;
    public float flashDuration = 1f;

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
        stamina = maxStamina;
        sprintSpeed = moveSpeed * sprintMultiplier;
        originalSpeed = moveSpeed;
        healthBar.UpdateHealth(health, maxHealth);

        sfxManager = FindFirstObjectByType<SFXManager>();
    }

    void Update()
    {
        moveAmount = horizontal * moveSpeed * Time.deltaTime;
        transform.position += new Vector3(moveAmount, 0f, 0f);

        // Ground check
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer);

        // Movement
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

        // Sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Sprint();
            timer = 0f;

            if (sprintBar.image.fillAmount <= 0)
            {
                Unsprint();
                timer += Time.deltaTime;

                if (timer >= regenDelay)
                {
                    stamina += staminaRegenAmount * Time.deltaTime;
                    sprintBar.UpdateSprint(stamina, maxStamina);
                }
            }
        }
        else
        {
            Unsprint();
            timer += Time.deltaTime;

            if (timer >= regenDelay)
            {
                stamina += staminaRegenAmount * Time.deltaTime;
                sprintBar.UpdateSprint(stamina, maxStamina);
            }
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            sfxManager.PlayJumpSFX();
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // Stamina
        stamina = Mathf.Clamp(stamina, 0f, maxStamina);

        // Walk/Run SFX
        bool isMoving = horizontal != 0f;
        bool isSprinting = Input.GetKey(KeyCode.LeftShift) && sprintBar.image.fillAmount > 0f;

        if (!isMoving || !isGrounded)
        {
            sfxManager.StopWalkRunSFXs();
        }
        else if (isSprinting)
        {
            sfxManager.PlayRunSFX();
        }
        else
        {
            sfxManager.PlayWalkSFX();
        }

        // Parrying

        if (Input.GetKeyDown(KeyCode.Mouse0) && isParrying == false && canParry == true)
        {
            parryScript.TryParry();
            parryScript.Flash(Color.white);

        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        healthBar.UpdateHealth(health, maxHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (!isParrying)
        {
            print("Object is not parrying");
            return;
        }

        GameObject theObject = collision.gameObject;

        if (!theObject.GetComponent<Meteor>() && !theObject.GetComponent<Enemy>())
        {
            print("Object is not a meteor or enemy");
            return;
        }

        parryScript.SuccessfulParry();
        Destroy(theObject);
    }

    void Sprint()
    {
        moveSpeed = sprintSpeed;
        stamina -= staminaDrain * Time.deltaTime;
        sprintBar.UpdateSprint(stamina, maxStamina);
    }

    void Unsprint()
    {
        moveSpeed = originalSpeed;
    }
}
