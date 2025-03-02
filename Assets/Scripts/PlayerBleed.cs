using UnityEngine;

public class PlayerBleed : MonoBehaviour
{
    public GameObject bloodVFXPrefab; // Allows VFX to be assigned in Inspector
    private GameObject activeBloodVFX;
    private PlayerController player; 

    void Start()
    {
        player = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (player.health <= 35)
        {
            if (activeBloodVFX == null) // Prevents duplicated VFX spawns
            {
                activeBloodVFX = Instantiate(bloodVFXPrefab, transform.position, Quaternion.identity, transform);
            }
        }
        else
        {
            if (activeBloodVFX != null)
            {
                Destroy(activeBloodVFX);
            }
        }

        // When player is hidden, hides VFX
        if (!gameObject.activeSelf && activeBloodVFX != null)
        {
            Destroy(activeBloodVFX);
        }
    }
}
