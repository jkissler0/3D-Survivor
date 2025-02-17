using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEditor.UI;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    public TextMeshProUGUI healthText;
    // private int count;
    private Vector2 moveInput;
    private Vector3 movement;
    public float speed = 0;
    public float health = 100;
    // private float damageCooldown = 1.0f;
    // private float lastDamageTime = 0f;

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

    private void OnTriggerEnter(Collider other)
    // private void OnTriggerStay(Collider other)
    {
        // if (other.gameObject.CompareTag("Enemy") && Time.time >= lastDamageTime + damageCooldown)
        if (other.gameObject.CompareTag("Enemy"))
        {
                health -= (50 * Time.fixedDeltaTime);
                // lastDamageTime = Time.time;
        }
    }

    void SetHealth()
    {
        int healthInt = Mathf.RoundToInt(health);
        healthText.text = healthInt.ToString();
        if (health <= 0)
        {
            healthText.color = Color.black;
            healthText.text = "You Lose!";
            this.gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        movement.x = moveInput.x * speed;
        movement.z = moveInput.y * speed;
        controller.Move(movement * Time.fixedDeltaTime);
        
        SetHealth();

    }
}
