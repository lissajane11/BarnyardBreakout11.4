using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Total collectibles in the game
    public int totalCollectibles;
    // Collected collectibles
    private int collectiblesCollected;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int score)
    {
        // Your existing score handling logic
    }

    public void CollectibleCollected()
    {
        collectiblesCollected++;
        Debug.Log($"Collectibles: {collectiblesCollected}/{totalCollectibles}");

        // Optional: Check if all collectibles are found
        if (collectiblesCollected == totalCollectibles)
        {
            Debug.Log("All collectibles found!");
            // You could trigger some event or level completion here
        }
    }
}