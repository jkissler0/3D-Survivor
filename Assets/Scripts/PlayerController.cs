using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEditor.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    public TextMeshProUGUI healthText;
    private Vector2 moveInput;
    private Vector3 movement;
    public float speed = 0;
    public float health = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        // count = 0;
    }

    void OnMove(InputValue movementValue)
    {
        moveInput = movementValue.Get<Vector2>();
    }


    private void OnTriggerStay(Collider other)
    {
        // Player will take damage every frame they're touching an enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
                health -= (50 * Time.fixedDeltaTime);
        }
    }

    void SetHealth()
    {
        // Rounds health to integer just in case and then updates the text
        // Sets text to "You Lose!" when the player dies
        int healthInt = Mathf.RoundToInt(health);
        healthText.text = healthInt.ToString();
        if (health <= 0)
        {
            healthText.color = Color.black;
            healthText.text = "You Lose!";
            this.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        // Scene will be reloaded when pressing space
        try
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("TestLevel");
                Debug.Log("It Worked");
            }
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    private void FixedUpdate()
    {
        movement.x = moveInput.x * speed;
        movement.z = moveInput.y * speed;
        controller.Move(movement * Time.fixedDeltaTime);
        
        SetHealth();
        
    }

    public Vector3 GetVelocity()
    {
        // Velocity getter function to use in the projectile controller to know the player's direction
        return movement;
    }
}
