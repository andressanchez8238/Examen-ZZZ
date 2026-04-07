using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform ubicacion_player;
    private NavMeshAgent agent;
    private GameObject Player;
    private void Awake()
    {
        Player = GameObject.FindWithTag("Player");
        if (Player != null)
        {
            ubicacion_player = Player.transform;
        }

    }
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        agent.SetAreaCost(0, 10);
        agent.SetAreaCost(3, 1);

    }


    void Update()
    {
        if (ubicacion_player != null)
        {
            agent.SetDestination(ubicacion_player.position);


            //agent.

        }
    }
    public void HasPath()
    {
        print(agent.hasPath);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (agent == null || agent.path == null) return;

        Vector3[] corners = agent.path.corners;


        for (int i = 0; i < corners.Length - 1; i++)
        {
            Gizmos.DrawLine(corners[i], corners[i + 1]);
            Gizmos.DrawSphere(corners[i], 0.2f);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bomb"))
        {
            Destroy(this.gameObject);
        }
    }
}
