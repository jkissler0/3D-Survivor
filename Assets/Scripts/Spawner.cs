using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    public GameObject basicEnemy;
    public GameObject fastEnemy;
    private double spawnTimer;
    private double spawnInterval = 3f;
    public double gameTimer;

    public Vector3 RandomNavmeshLocation(float radius)
    {
        // Somewhat complicated function that will return the closest NavMesh position to a random point selected
        // within a sphere of the given radius
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
        // Every 15 seconds, enemies will begin to spawn faster
        gameTimer += 0.02;
        if (gameTimer >= 15)
        {
            spawnInterval = spawnInterval * 0.75;
            gameTimer = 0;
        }

        // Spawns an enemy every [spawnInterval] seconds
        // Fast enemies should only spawn ~1/4 of the time
        if (spawnTimer < spawnInterval) {
            spawnTimer += 0.02;
        } else {
            // Spawn enemy
            float randSpawn = Random.value;
            if (randSpawn < 0.75)
            {
                Vector3 spawnPos = RandomNavmeshLocation(95);
                Instantiate(basicEnemy, spawnPos, Quaternion.identity, this.gameObject.transform);
                spawnTimer = 0;
            } else
            {
                Vector3 spawnPos = RandomNavmeshLocation(95);
                Instantiate(fastEnemy, spawnPos, Quaternion.identity, this.gameObject.transform);
                spawnTimer = 0;
            }
            
        }
    }
}
