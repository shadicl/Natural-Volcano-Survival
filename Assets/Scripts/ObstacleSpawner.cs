using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private Transform floor;

    [SerializeField] private int obstacleCount = 25;
    [SerializeField] private float minDistance = 20f;
    [SerializeField] private float maxDistance = 30f;
    [SerializeField] private float startingOffset = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnObstacles();
    }

    private void SpawnObstacles()
    {

        Collider2D floorCollider = floor.GetComponent<Collider2D>();

        float currentX = floor.position.x - floor.localScale.x / 2f + startingOffset;
        float floorTop = floorCollider.bounds.max.y;

        for (int i = 0; i < obstacleCount; i++)
        {
            int randomIndex = Random.Range(0, obstacles.Length);

            float distance = Random.Range(minDistance, maxDistance);
            currentX += distance;

            GameObject obstacle = Instantiate(
                obstacles[randomIndex],
                new Vector3(currentX, floorTop, 0),
                Quaternion.identity
            );

            SpriteRenderer sprite = obstacle.GetComponent<SpriteRenderer>();

            if (sprite != null)
            {
                float halfHeight = sprite.bounds.extents.y;

                obstacle.transform.position += new Vector3(0, halfHeight, 0);
            }
        }
    }
}
