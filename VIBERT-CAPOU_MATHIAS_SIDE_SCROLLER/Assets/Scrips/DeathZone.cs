using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private Transform playerSpawn;

    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform; //Finds the players spawn point
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           collision.transform.position = playerSpawn.position; //Moves the player to the spawn point
            Debug.Log("Player has died");
        }
    }
}


