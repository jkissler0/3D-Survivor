using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    // private int count;
    private Vector2 moveInput;
    private Vector3 movement;
    public float speed = 0;
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


    private void FixedUpdate()
    {
        movement.x = moveInput.x * speed;
        movement.z = moveInput.y * speed;
        controller.Move(movement * Time.fixedDeltaTime);
    }
}
