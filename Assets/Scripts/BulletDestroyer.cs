using System.Collections;
using UnityEngine;

public class BulletDestroyer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("World"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator SelfDestruct()
    {
        // Destroys bullet object after it exists for 3 seconds
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
