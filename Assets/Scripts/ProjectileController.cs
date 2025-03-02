using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public GameObject bulletObject;
    public GameObject orbiterObject;
    public GameObject player;
    private PlayerController playerController;
    public float launchVelocity = 700f;
    private Vector3 playerDirection;
    private double cooldownTimer;
    private double autoTimer = 0;

    private void Start()
    {
        playerDirection = new Vector3(0, 0, 1);
        // Gets player controller script so the GetVelocity() function from it can be called later
        playerController = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        
        
        if (playerController.GetVelocity().normalized != Vector3.zero)
        {
            // A normalized vector can be used to represent the player's direction
            playerDirection = playerController.GetVelocity().normalized;
        }
        
        // Fires a bullet when clicking if the cooldown is ready
        if (Input.GetButton("Fire1") && (cooldownTimer > 0.25))
        {
            CreateBullet();
        }

        if (autoTimer >= 2)
        {
            CreateOrbiter();
        }

        cooldownTimer += Time.deltaTime;
        autoTimer += Time.deltaTime;
    }

    // Spawn bullet with velocity that's equal to the normalized direction vector * launch speed
    void CreateBullet()
    {
        Vector3 spawnOffset = playerDirection * 1.5f; // Move spawn point slightly forward
        Vector3 spawnPosition = transform.position + spawnOffset;
        Debug.Log("Bullet Position:" + spawnPosition);

        GameObject bullet = Instantiate(bulletObject, spawnPosition, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddRelativeForce(launchVelocity * playerDirection);
        cooldownTimer = 0;
    }

    //
    void CreateOrbiter()
    {
        Vector3 spawnPosition = transform.position;
        Debug.Log("Orbit Position:" + spawnPosition);

        GameObject orbiter = Instantiate(orbiterObject, spawnPosition, Quaternion.identity);
        autoTimer = -2;
    }
}
