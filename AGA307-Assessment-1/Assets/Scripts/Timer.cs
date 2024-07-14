using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int timeRemaining = 180;
    public GameObject timerText;
    public GameObject gameOverScreen;

    public GameObject playerPrefab;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        // Run the countdown coroutine
        StartCoroutine(CountDown());
    }

    // Update is called once per frame
    void Update()
    {
        // Update the timer text
        timerText.GetComponent<Text>().text = "Time: " + timeRemaining.ToString();
    }

    public IEnumerator CountDown()
    {
        while (timeRemaining > 0)
        {
            // Counts down timer
            yield return new WaitForSeconds(1);
            timeRemaining--;
        }

        // Show the game over screen when the timer reaches zero
        SetGameOverScreen(true);
    }

    public void SetGameOverScreen(bool isActive)
    {
        if (gameOverScreen != null)
        {
            // Destroy the player
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                Destroy(player);
            }

            // Activate the game over screen
            gameOverScreen.SetActive(isActive);
        }
        else
        {
            Debug.LogWarning("Game Over screen is not assigned.");
        }
    }
    public void ResetGame()
    {
        // Deactivate the game over screen
        SetGameOverScreen(false);

        // Reset timer
        timeRemaining = 180;

        // Respawn the player (assuming you have a method to do this)
        RespawnPlayer();

        // Restart the countdown
        StartCoroutine(CountDown());
    }

    private void RespawnPlayer()
    {
        // Ensure the player prefab and spawn point are assigned
        if (playerPrefab != null && spawnPoint != null)
        {
            Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Debug.LogWarning("Player prefab or spawn point is not assigned.");
        }
    }
}

