using UnityEngine;
using UnityEngine.InputSystem;

public class GiftBox : MonoBehaviour
{
    public int pressesNeeded = 3;

    public GameObject ballPrefab;
    public Transform spawnPoint;

    private int currentPresses = 0;
    private bool playerNearby = false;

    void Update()
    {
        if (playerNearby &&
            Keyboard.current != null &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {
            currentPresses++;

            Debug.Log("E Presses: " + currentPresses + "/" + pressesNeeded);

            if (currentPresses >= pressesNeeded)
            {
                Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);

                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}