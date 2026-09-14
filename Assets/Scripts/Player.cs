using UnityEngine;

public class Player : MonoBehaviour
{

    private float moveAmount;
    [SerializeField] private float moveSpeed = 10f;

    float horizontal;

    void Start()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    void Update()
    {
        moveAmount = horizontal * moveSpeed * Time.deltaTime;
        transform.position += new Vector3(moveAmount, 0f, 0f);

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
    }
}
