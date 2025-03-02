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
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();

        if (playerController.GetVelocity().normalized != Vector3.zero)
        {
            playerDirection = playerController.GetVelocity().normalized;
        }
        
        if (Input.GetButtonDown("Fire1"))
        {

            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddRelativeForce(launchVelocity * playerDirection);

        }
    }
}
