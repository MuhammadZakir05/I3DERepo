using UnityEngine;

public class ContinuousMovementRotation : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float positionLimit = 10f;
    private Vector3 moveDirection = Vector3.forward;

    [Header("Rotation")]
    public float rotationSpeed = 100f;
    public float rotationLimit = 45f;
    private float rotationDirection = 1f;

    void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    void HandleMovement()
    {
        // Move continuously
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        Vector3 pos = transform.position;

        // Reverse direction when hitting boundary
        if (pos.x > positionLimit || pos.x < -positionLimit)
            moveDirection.x *= -1;

        if (pos.y > positionLimit || pos.y < -positionLimit)
            moveDirection.y *= -1;

        if (pos.z > positionLimit || pos.z < -positionLimit)
            moveDirection.z *= -1;
    }

    void HandleRotation()
    {
        // Rotate continuously
        transform.Rotate(0, rotationSpeed * rotationDirection * Time.deltaTime, 0);

        float yRotation = transform.eulerAngles.y;

        // Convert to -180 to 180
        if (yRotation > 180) yRotation -= 360;

        // Reverse rotation when limit reached
        if (yRotation > rotationLimit || yRotation < -rotationLimit)
        {
            rotationDirection *= -1;
        }
    }
}