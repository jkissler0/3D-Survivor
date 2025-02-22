using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject basicEnemy;
    public GameObject fastEnemy;
    public GameObject level;
    public Transform player;
    private double timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var sizeX = level.GetComponent<Renderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        if (timer < 50) {
            timer += 0.02;
        } else {
            // Spawn enemy
            timer = 0;
        }
    }
}
