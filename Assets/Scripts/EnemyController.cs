using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float health = 100;
    public float damage = 35;
    private NavMeshAgent navMeshAgent;

    public GameObject enemyBleedVFX; // Assign Bleed VFX in Editor
    public GameObject enemyDeathVFX; // Assign Death VFX in Editor
    private GameObject activeBleedEffect; // Store reference to bleeding effect

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            navMeshAgent.SetDestination(player.position);
        }

        // Trigger Bleeding Effect if health is below 50
        if (health < 50 && enemyBleedVFX != null && activeBleedEffect == null)
        {
            activeBleedEffect = Instantiate(enemyBleedVFX, transform.position, Quaternion.identity, transform);
        }

        // Enemy dies and spawns VFX
        if (health <= 0)
        {
            GameObject.Find("GameManager").GetComponent<ScoreCounter>().AddElimination();
            PlayDeathEffect();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            health -= damage;
        }
    }

    private void PlayDeathEffect()
    {
        if (enemyDeathVFX != null)
        {
            Instantiate(enemyDeathVFX, transform.position, Quaternion.identity);
        }
    }
}
