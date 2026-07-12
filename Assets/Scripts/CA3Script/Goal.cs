using UnityEngine;

public class Goal : MonoBehaviour
{
    public int score = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            score++;

            Debug.Log("Score: " + score);

            Destroy(other.gameObject);
        }
    }
}