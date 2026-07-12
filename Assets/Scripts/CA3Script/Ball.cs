using UnityEngine;
using UnityEngine.InputSystem;

public class Ball : MonoBehaviour
{
    public float force = 10f;
    public float interactDistance = 2f;

    private Rigidbody rb;
    private Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= interactDistance)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                rb.AddForce(player.forward * force, ForceMode.Impulse);
            }
        }
    }
}