using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehavior {
  public GameObject projectile;
  public float launchVelocity = 700f;

  void Update() {

    if (Input.GetButtonDown("Fire1")) {

      GameObject bullet = Instantiate (projectile, transform.position, transform.rotation);

      bullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3 (0, 5, launchVelocity);

    }
    
  }

}


