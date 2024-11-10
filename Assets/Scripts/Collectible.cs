using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Amount of score to give when collected (optional)
    public int scoreValue = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object colliding is the player (assuming player is tagged "Player")
        if (other.CompareTag("Player"))
        {
            // Add to the player's score (assuming a GameManager handles the score)
            GameManager.instance.AddScore(scoreValue);

            // Play a sound effect, animation, etc. (optional)
            // AudioSource.PlayClipAtPoint(collectSound, transform.position);

            // Destroy the collectible after being collected
            Destroy(gameObject);
        }
    }
}