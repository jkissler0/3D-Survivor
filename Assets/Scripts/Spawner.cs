using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    public GameObject basicEnemy;
    public GameObject fastEnemy;
    private double timer;

    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        while (finalPosition.y > 2)
        {
            finalPosition = RandomNavmeshLocation(radius);
        }
        return finalPosition;
    }

    void FixedUpdate()
    {
        if (timer < 5) {
            timer += 0.02;
        } else {
            // Spawn enemy
            float randSpawn = Random.value;
            if (randSpawn < 0.75)
            {
                Vector3 spawnPos = RandomNavmeshLocation(95);
                Instantiate(basicEnemy, spawnPos, Quaternion.identity, this.gameObject.transform);
                timer = 0;
            } else
            {
                Vector3 spawnPos = RandomNavmeshLocation(95);
                Instantiate(fastEnemy, spawnPos, Quaternion.identity, this.gameObject.transform);
                timer = 0;
            }
            
        }
    }
}
