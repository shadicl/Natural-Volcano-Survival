using System.Collections;
using UnityEngine;

public class Meteor : MonoBehaviour
{

    [SerializeField] private float rotateSpeed = 100f;

    public float damageAmount = 20f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

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
            player.health = Mathf.Clamp(player.health - damageAmount, 0f, 100f);
            Destroy(gameObject, 0.0f);
        }
        else if (collision.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject, 0.0f);
        }
    }
}
