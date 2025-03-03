using UnityEngine;

public class LaunchController2 : MonoBehaviour
{
    public GameObject projectile;
    public float launchVelocity = 700f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {

            GameObject bullet = Instantiate(projectile, transform.position, transform.rotation);

            bullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(-launchVelocity, 0, 0));

        }
    }
}
