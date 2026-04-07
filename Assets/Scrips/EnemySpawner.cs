using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float range = 10f;
    public float spawnInterval = 2f;
    public bool EnableSpawner;

    public float counter;

    void Start()
    {
        GetComponent<SphereCollider>().radius = range;
    }
    void Update()
    {
        if (EnableSpawner)
        {
            counter += Time.deltaTime;
            if (counter > spawnInterval)
            {


                SpawnEnemy();


                counter = 0f;

            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.aliceBlue;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void SpawnEnemy()
    {
        GameObject obj = Instantiate(EnemyPrefab);


        Vector3 origin = transform.position;

        Vector3 dir = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;

        Vector3 FinalPosition = origin + dir * Random.Range(0, range);

        obj.transform.position = FinalPosition;
    }
}