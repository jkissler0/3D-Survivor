using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public Transform player;
    public float health = 100;
    private NavMeshAgent navMeshAgent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Set Agent Pathing
        if (player != null)
        {
            navMeshAgent.SetDestination(player.position);
        }

        // When enemy dies
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Take half of enemies' health away when being hit by a bullet
        if (other.gameObject.CompareTag("Weapon"))
        {
            health -= 50;
        }
    }
}

