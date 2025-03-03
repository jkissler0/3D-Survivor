using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    public TextMeshProUGUI healthText;
    // private int count;
    private Vector2 moveInput;
    private Vector3 movement;
    public float speed = 0;
    public float health = 100;
    //animator
    public float moveSpeed = 5f; // Default movement speed
    public float walkSpeed = 2.5f; // Walking speed

    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        // count = 0;
        anim = GetComponentInChildren<Animator>();
    }

    void OnMove(InputValue movementValue)
    {
        moveInput = movementValue.Get<Vector2>();
    }
    // animator
    private void Idle()
    {
        anim.SetFloat("Speed", 0);
    }
    private void Walk()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed", moveSpeed / 0.5f);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            health -= (50 * Time.fixedDeltaTime);
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

        // Rotation: Smoothly rotate towards movement direction
        if (movement != Vector3.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward, movement.normalized, Time.deltaTime * 10f);
            Walk(); // Play walking animation when moving
        }
        else
        {
            Idle(); // Play idle animation when not moving
        }
        SetHealth();
    }
}
