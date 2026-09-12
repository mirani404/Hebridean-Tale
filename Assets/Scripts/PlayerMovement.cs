using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.linearDamping = 5f;
    }

    void Update()
    {
        MyInputs();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInputs()
    {
        Keyboard kb = Keyboard.current;

        verticalInput = 0f;
        if (kb.wKey.isPressed) verticalInput += 1f;
        if (kb.sKey.isPressed) verticalInput -= 1f;

        horizontalInput = 0f;
        if (kb.dKey.isPressed) horizontalInput += 1f;
        if (kb.aKey.isPressed) horizontalInput -= 1f;
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
}