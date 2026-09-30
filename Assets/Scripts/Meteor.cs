using System.Collections;
using UnityEngine;

public class Meteor : MonoBehaviour
{

    [SerializeField] private float rotateSpeed = 100f;
    private GameObject healthFill;

    public float damageAmount = 20f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if (player != null)
            {
                player.TakeDamage(damageAmount);
                Destroy(gameObject, 0.0f);
            }
        }
        else if (collision.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject, 0.0f);
        }
    }
}
