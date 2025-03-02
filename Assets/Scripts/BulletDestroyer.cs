using System.Collections;
using UnityEngine;

public class BulletDestroyer : MonoBehaviour
{
    public GameObject destroyVFX; // Assigned in Editor

    void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("World") || collision.gameObject.CompareTag("Enemy"))
        {
            PlayEffect();
            Destroy(gameObject);
        }
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(3f);
        PlayEffect();
        Destroy(gameObject);
    }

    private void PlayEffect()
    {
        if (destroyVFX != null) 
        {
            Instantiate(destroyVFX, transform.position, Quaternion.identity);
        }
    }
}
