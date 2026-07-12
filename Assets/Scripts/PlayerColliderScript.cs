using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class PlayerColliderScript : MonoBehaviour
{public int scoreIncrement = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int CoinsCollected = 0;

    GameObject currentCoin;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            currentCoin = collision.gameObject;
        }
        
    }

    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag =="Coin")
        {
            currentCoin = null;
        }
    }

    // Update is called once per frame
    void OnInteract(InputValue value)
    {
        if(currentCoin != null)
        {
        CoinInc coin = currentCoin.GetComponent<CoinInc>();
        CoinsCollected += coin.scoreValue;
        Destroy(currentCoin);
            print($"Score: {CoinsCollected}");
        }
    }
    /// Summary
    /// Triggers when player touches the platform
    /// </summary>
    /// <param name="other">Other object that the player collided with <param name>

    void OnTriggerEnter(Collider other)
    {
        if(CoinsCollected == 4)
        {
            print("Congratulations!!");
        }
    }
}
