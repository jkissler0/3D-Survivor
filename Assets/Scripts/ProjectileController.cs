using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public GameObject projectile;
    public float launchVelocity = 700f;

    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {

            Debug.Log("The conditional is working");
            GameObject bullet = Instantiate(projectile, transform.position, transform.rotation);

            bullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, launchVelocity));

        }
    }
}
