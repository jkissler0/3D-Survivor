using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEditor.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    public TextMeshProUGUI healthText;
    // private int count;
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

    private void Update()
    {
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
}
