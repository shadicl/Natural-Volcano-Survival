using System.Collections;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{

    private bool isDelaying = false;
    [SerializeField] private GameObject meteorPrefab;
    [SerializeField] private GameObject floor;

    [SerializeField] private float spawnRate = 0.25f;

    private float startX;
    private float endX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BoxCollider2D floorCollider = floor.GetComponent<BoxCollider2D>();

        if (floorCollider != null)
        {
            startX = floorCollider.bounds.min.x;
            endX = floorCollider.bounds.max.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDelaying)
        {
            SpawnMeteor();
            StartCoroutine(Delay());
        }
       
    }

    private void SpawnMeteor()
    {
        float randomSpot = Random.Range(startX, endX);

        GameObject meteorClone = Instantiate(meteorPrefab, transform.position, Quaternion.identity);

        meteorClone.transform.position = new Vector3(randomSpot, transform.position.y, transform.position.z);
    }

    private IEnumerator Delay()
    {
        isDelaying = true;

        yield return new WaitForSeconds(spawnRate);

        isDelaying = false;
    }
}
