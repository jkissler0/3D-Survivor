using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public GameObject projectile;
    public GameObject player;
    private PlayerController playerController;
    public float launchVelocity = 700f;
    private Vector3 playerDirection;

    private void Start()
    {
        playerDirection = new Vector3(0, 0, 1);
    }

    void Update()
    {
        // Gets player gameObject so the GetVelocity() function from it can be called
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        if (playerController.GetVelocity().normalized != Vector3.zero)
        {
            // A normalized vector can be used to represent the player's direction
            playerDirection = playerController.GetVelocity().normalized;
        }
        
        // Spawn bullet when clicking with velocity that's equal to the normalized direction vector * launch speed
        if (Input.GetButtonDown("Fire1"))
        {

            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddRelativeForce(launchVelocity * playerDirection);

        }
    }
}
